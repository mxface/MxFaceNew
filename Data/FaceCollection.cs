using Neurotec.Biometrics;
using Neurotec.Images;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Neurotec.Samples.Data
{
	public class FaceRecordCollection: IEnumerable<FaceRecord>
	{
		#region Private constants

		private const string TableName = "WatchList";

		#endregion

		#region Private fields

		private readonly SQLiteConnection _sqliteConnection;
		private readonly Dictionary<string, FaceRecord> _dictionary = new Dictionary<string, FaceRecord>();

		#endregion

		#region Public constructor

		public FaceRecordCollection(string dbFile)
		{
			_sqliteConnection = new SQLiteConnection("Version=3;New=False;Compress=False;Data Source=" + dbFile);
			try
			{
				_sqliteConnection.Open();
			}
			catch (SQLiteException ex)
			{
				MessageBox.Show(string.Format("{0}. StackTrace: {1}", ex.Message, ex.StackTrace));
			}
			if (_sqliteConnection.State == ConnectionState.Open)
			{
				var select = new SQLiteCommand(
					string.Format("SELECT id, features, faceId, enrollTime, " +
						"faceRectangleX, faceRectangleY, faceRectangleWidth, faceRectangleHeight, rectRoll, " +
						"leftEyeConfidence, leftEyeX, leftEyeY, rightEyeConfidence, rightEyeX, rightEyeY FROM {0}", TableName), _sqliteConnection);
				SQLiteDataReader reader = select.ExecuteReader();
				while (reader.Read())
				{
					int id = reader.GetInt32(0);
					long featuresSize = reader.GetBytes(1, 0, null, 0, 0);
					byte[] features = new byte[featuresSize];
					reader.GetBytes(1, 0, features, 0, (int)featuresSize);
					string faceId = reader.GetString(2);
					var enrollTime = reader.GetDateTime(3);
					var attributes = new NLAttributes();
					attributes.BoundingRect = new Neurotec.Drawing.Rectangle(reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));
					attributes.Roll = reader.GetFloat(8);
					var leftEye = new NLFeaturePoint();
					leftEye.Confidence = (byte)reader.GetInt32(9);
					leftEye.X = (ushort)reader.GetInt32(10);
					leftEye.Y = (ushort)reader.GetInt32(11);
					attributes.LeftEyeCenter = leftEye;
					var rightEye = new NLFeaturePoint();
					rightEye.Confidence = (byte)reader.GetInt32(12);
					rightEye.X = (ushort)reader.GetInt32(13);
					rightEye.Y = (ushort)reader.GetInt32(14);
					attributes.RightEyeCenter = rightEye;

					_dictionary[faceId] = new FaceRecord(id, features, faceId, enrollTime, attributes);
				}
				reader.Close();
			}
		}

		#endregion

		#region Public static methods

		public static void CheckCreateDB(string fileName)
		{
			if (!File.Exists(fileName))
			{
				SQLiteConnection.CreateFile(fileName);

				using (var conn = new SQLiteConnection("Version=3;New=True;Compress=False;Data Source=" + fileName))
				{
					try
					{
						conn.Open();
						CreateTable(conn);
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Could not create database tables, reason: {ex.Message}");
					}
				}
			}
		}
		#endregion

		#region Public properties

		public FaceRecord this[string faceId]
		{
			get
			{
				return _dictionary.TryGetValue(faceId, out var value) ? value : null;
			}
		}

		#endregion

		#region Public methods

		public void Close()
		{
			_sqliteConnection.Close();
		}

		public void Add(FaceRecord faceRecord, NImage image, NImage thumbnail)
		{
			int id = WriteToDb(faceRecord.Features, faceRecord.FaceId, image, thumbnail, faceRecord.EnrollTime, faceRecord.Attributes);
			if (id >= 0)
			{
				faceRecord.Id = id;
				_dictionary[faceRecord.FaceId] = faceRecord;
			}
		}

		public void Clear()
		{
			_dictionary.Clear();
			using (SQLiteCommand deleteAll = new SQLiteCommand(String.Format("DELETE FROM {0}", TableName), _sqliteConnection))
			{
				deleteAll.ExecuteNonQuery();
			}
		}

		public void Delete(string faceId)
		{
			using (var deleteCommand = new SQLiteCommand($"DELETE FROM {TableName} WHERE faceId=@faceid", _sqliteConnection))
			{
				deleteCommand.Parameters.AddWithValue("@faceid", faceId);
				int sd = deleteCommand.ExecuteNonQuery();
				_dictionary.Remove(faceId);
			}
		}

		public NImage GetImageById(int id)
		{
			NImage image = null;
			SQLiteCommand select = new SQLiteCommand(
				string.Format("SELECT picture FROM {0} WHERE id = {1}", TableName, id), _sqliteConnection);
			using (SQLiteDataReader reader = select.ExecuteReader())
			{
				while (reader.Read())
				{
					long fieldSize = reader.GetBytes(0, 0, null, 0, 0);
					byte[] bytes = new byte[fieldSize];
					reader.GetBytes(0, 0, bytes, 0, (int)fieldSize);
					using (var stream = new MemoryStream(bytes))
					{
						image = NImage.FromMemory(bytes);
					}
				}
			}
			return image;
		}

		public NImage GetThumbnailById(int id)
		{
			NImage image = null;
			SQLiteCommand select = new SQLiteCommand($"SELECT thumbnail FROM {TableName} WHERE id = {id}", _sqliteConnection);
			using (var reader = select.ExecuteReader())
			{
				if (reader.Read())
				{
					long fieldSize = reader.GetBytes(0, 0, null, 0, 0);
					byte[] bytes = new byte[fieldSize];
					reader.GetBytes(0, 0, bytes, 0, (int)fieldSize);
					using (MemoryStream stream = new MemoryStream(bytes))
					{
						image = NImage.FromMemory(bytes);
					}
				}
			}
			return image;
		}

		public int GetCount()
		{
			return _dictionary.Count;
		}

		public bool TryGetValue(string faceId, out FaceRecord value)
		{
			value = null;
			return _dictionary.TryGetValue(faceId, out value);
		}

		#endregion

		#region Private methods

		private int WriteToDb(byte[] features, string faceId, NImage nImage, NImage thumnail, DateTime enrollTime, NLAttributes attributes)
		{
			int maxId = -1;
			try
			{
				var checkAlreadyPresent = new SQLiteCommand(string.Format("SELECT id FROM {0} WHERE faceid=@faceid", TableName), _sqliteConnection);
				checkAlreadyPresent.Parameters.AddWithValue("@faceid", faceId);
				using (SQLiteDataReader reader = checkAlreadyPresent.ExecuteReader())
				{
					if (reader.Read())
					{
						return reader.GetInt32(0);
					}
				}

				using (var buffer = nImage.Save(NImageFormat.Jpeg))
				using (var thumb = thumnail.Save(NImageFormat.Jpeg))
				{
					string cmdstr = string.Format(
						"INSERT INTO {0} (features, faceId, picture, thumbnail, enrollTime, " +
						"faceRectangleX, faceRectangleY, faceRectangleWidth, faceRectangleHeight, rectRoll, " +
						"leftEyeConfidence, leftEyeX, leftEyeY, rightEyeConfidence, rightEyeX, rightEyeY) " +
						"VALUES (@features, @faceId, @picture, @thumbnail, @enrollTime, " +
						"@faceRectangleX, @faceRectangleY, @faceRectangleWidth, @faceRectangleHeight, @rectRoll, " +
						"@leftEyeConfidence, @leftEyeX, @leftEyeY, @rightEyeConfidence, @rightEyeX, @rightEyeY)", TableName);

					var insert = new SQLiteCommand(cmdstr, _sqliteConnection);
					insert.Parameters.AddWithValue("@features", features);
					insert.Parameters.AddWithValue("@faceId", faceId);
					insert.Parameters.AddWithValue("@picture", buffer.ToArray());
					insert.Parameters.AddWithValue("@thumbnail", thumb.ToArray());
					insert.Parameters.AddWithValue("@enrollTime", enrollTime);
					insert.Parameters.AddWithValue("@faceRectangleX", attributes.BoundingRect.X);
					insert.Parameters.AddWithValue("@faceRectangleY", attributes.BoundingRect.Y);
					insert.Parameters.AddWithValue("@faceRectangleWidth", attributes.BoundingRect.Width);
					insert.Parameters.AddWithValue("@faceRectangleHeight", attributes.BoundingRect.Height);
					insert.Parameters.AddWithValue("@rectRoll", attributes.Roll);
					insert.Parameters.AddWithValue("@leftEyeConfidence", attributes.LeftEyeCenter.Confidence);
					insert.Parameters.AddWithValue("@leftEyeX", attributes.LeftEyeCenter.X);
					insert.Parameters.AddWithValue("@leftEyeY", attributes.LeftEyeCenter.Y);
					insert.Parameters.AddWithValue("@rightEyeConfidence", attributes.RightEyeCenter.Confidence);
					insert.Parameters.AddWithValue("@rightEyeX", attributes.RightEyeCenter.X);
					insert.Parameters.AddWithValue("@rightEyeY", attributes.RightEyeCenter.Y);
					insert.ExecuteNonQuery();

					var getMaxId = new SQLiteCommand(string.Format("SELECT MAX(id) FROM {0}", TableName), _sqliteConnection);
					maxId = (int)(long)getMaxId.ExecuteScalar();
				}
			}
			catch (InvalidOperationException ex)
			{
				MessageBox.Show(string.Format("Failed to insert record into DB:\n{0}", ex.Message));
			}
			if (maxId == -1)
			{
				MessageBox.Show(@"Error. Cannot get id from database! Description: function writeToDB");
			}

			return maxId;
		}
		
		#endregion

		#region Private static methods

		private static void CreateTable(SQLiteConnection conn)
		{
			var cmd = new SQLiteCommand(
				"CREATE TABLE WatchList (" +
				"[id] INTEGER PRIMARY KEY, " +
				"[features] BINARY, " +
				"[faceId] TEXT, " +
				"[picture] IMAGE, " +
				"[thumbnail] IMAGE, " +
				"[enrollTime] TIMESTAMP, " +
				"[faceAvailable] BOOL, " +
				"[faceRectangleX] INTEGER, " +
				"[faceRectangleY] INTEGER, " +
				"[faceRectangleWidth] INTEGER, " +
				"[faceRectangleHeight] INTEGER, " +
				"[rectRoll] FLOAT, " +
				"[leftEyeConfidence] INTEGER, " +
				"[leftEyeX] INTEGER, " +
				"[leftEyeY] INTEGER, " +
				"[rightEyeConfidence] INTEGER, " +
				"[rightEyeX] INTEGER, " +
				"[rightEyeY] INTEGER, " +
				"[comment] TEXT)", conn);
			cmd.ExecuteNonQuery();
		}

		#endregion

		#region IEnumerable

		public IEnumerator<FaceRecord> GetEnumerator()
		{
			return _dictionary.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _dictionary.Values.GetEnumerator();
		}

		#endregion

	}

	public class FaceRecord
	{

		#region Public properties

		public int Id { get; set; }
		public byte[] Features { get; private set; }
		public string FaceId { get; private set; }
		public DateTime EnrollTime { get; set; }
		public NLAttributes Attributes { get; set; }

		#endregion

		#region Public constructor

		public FaceRecord(int id, byte[] features, string faceId, DateTime enrollTime, NLAttributes attributes)
		{
			this.Id = id;
			this.Features = features;
			this.FaceId = faceId;
			this.EnrollTime = enrollTime;
			this.Attributes = new NLAttributes
			{
				BoundingRect = attributes.BoundingRect,
				Roll = attributes.Roll,
				LeftEyeCenter = attributes.LeftEyeCenter,
				RightEyeCenter = attributes.RightEyeCenter,
			};
		}

		#endregion

	}
}
