using Neurotec.Images;
using Neurotec.IO;
using Neurotec.Surveillance;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neurotec.Samples.Data
{
	public enum Order
	{
		Descending,
		Ascending
	}

	public enum WatchlistFilter
	{
		[Description("Any")]
		Any,
		[Description("In Watchlist")]
		InWatchlist,
		[Description("Not In Watchlist")]
		NotInWatchlist
	}

	public class RecordCollection
	{
		#region Private types

		private class DataType
		{
			public DataType()
			{
			}

			public DataType(Record r)
			{
				Face = r.Face;
				Lpr = r.License;
				Object = r.Object;
			}

			public FullFaceRecord Face { get; set; }
			public LicenseRecord Lpr { get; set; }
			public ObjectRecord Object { get; set; }
		}

		#endregion

		#region Private constants

		private const string RecordsTable = "RecordsTable";
		private const string ReadFieldsWithoutImages = "id, timestamp, videoOffset, isVideoSource, source, data";
		private const string ReadFieldsWithImages = "id, image, timestamp, videoOffset, isVideoSource, source, data, objectThumbnail, lpThumbnail, faceThumbnail";

		#endregion

		#region Private fields

		private readonly SQLiteConnection _sqliteConnection;
		private SemaphoreSlim _semaphore = new SemaphoreSlim(1);

		#endregion

		#region Public constructor

		public RecordCollection(string dbFile)
		{
			_sqliteConnection = new SQLiteConnection("Version=3;New=False;Compress=False;foreign keys=true;Data Source=" + dbFile);
			try
			{
				_sqliteConnection.Open();
			}
			catch (SQLiteException ex)
			{
				MessageBox.Show(string.Format("{0}. StackTrace: {1}", ex.Message, ex.StackTrace));
			}
		}

		#endregion

		#region Public methods

		public void Close()
		{
			_sqliteConnection.Close();
		}

		public async Task AddAsync(Record record)
		{
			using (record)
			{
				await _semaphore.WaitAsync();
				try
				{
					var query = $@"INSERT INTO {RecordsTable}
						(image, timestamp, videoOffset, isVideoSource, source, data, car, person, bus, truck, bike, objectThumbnail, lpThumbnail, faceThumbnail, inWatchlist)
						VALUES
						(@image, @timestamp, @videoOffset, @isVideoSource, @source, @data, @car, @person, @bus, @truck, @bike, @objectThumbnail, @lpThumbnail, @faceThumbnail, @inWatchlist);";

					using (var insert = new SQLiteCommand(query, _sqliteConnection))
					{
						var dataValue = new DataType(record);
						var data = JsonConvert.SerializeObject(dataValue);

						using (var image = SaveImage(record.Image))
						using (var objThumb = SaveBitmap(record.Object?.Thumbnail))
						using (var faceThumb = SaveBitmap(record.Face?.Thumbnail))
						using (var lprThumb = SaveBitmap(record?.License?.Thumbnail))
						{
							insert.Parameters.AddWithValue("@image", image?.ToArray());
							insert.Parameters.AddWithValue("@timestamp", record.TimeStamp);
							insert.Parameters.AddWithValue("@videoOffset", record.VideoTimeStamp.Ticks);
							insert.Parameters.AddWithValue("@isVideoSource", record.IsVideoSource);
							insert.Parameters.AddWithValue("@source", record.Source);

							insert.Parameters.AddWithValue("@data", data);

							insert.Parameters.AddWithValue("@car", record.Object?.CarConfidence);
							insert.Parameters.AddWithValue("@person", record.Object?.PersonConfidence);
							insert.Parameters.AddWithValue("@bus", record.Object?.BusConfidence);
							insert.Parameters.AddWithValue("@truck", record.Object?.TruckConfidence);
							insert.Parameters.AddWithValue("@bike", record.Object?.BikeConfidence);

							insert.Parameters.AddWithValue("@objectThumbnail", objThumb?.ToArray());
							insert.Parameters.AddWithValue("@lpThumbnail", lprThumb?.ToArray());
							insert.Parameters.AddWithValue("@faceThumbnail", faceThumb?.ToArray());

							bool inWatchlist = record.License?.InWatchlist == true || record.Face?.Match != null;
							insert.Parameters.AddWithValue("@inWatchlist", inWatchlist);

							await insert.ExecuteNonQueryAsync();
						}
					}
				}
				finally
				{
					_semaphore.Release();
				}
			}
		}

		public void ClearWeekOld()
		{
			var cutOff = (DateTime.Now - TimeSpan.FromDays(7)).ToUniversalTime();
			string query = $@"DELETE FROM {RecordsTable} WHERE timestamp <= '{cutOff.ToString("yyyy-MM-dd HH:mm:ss")}'";
			using (var cmd = new SQLiteCommand(query, _sqliteConnection))
			{
				try
				{
					cmd.ExecuteNonQuery();
				}
				catch (SQLiteException ex)
				{
					MessageBox.Show($"Could not clear database, reason: {ex.Message}");
				}
			}
		}

		public Task<List<Record>> GetObjectsWithLicenseAsync(int limit, DateTime fromTime, Order order, int? fromId = null, bool withThumbnails = true, string sourceFilter = null,
			WatchlistFilter watchlistFilter = WatchlistFilter.Any)
		{
			var type = NSurveillanceModalityType.VehiclesAndHumans | NSurveillanceModalityType.LicensePlateRecognition;
			return ReadRecordsAsync(limit, fromTime, order, type, fromId, withThumbnails, sourceFilter, watchlistFilter: watchlistFilter);
		}

		public Task<List<Record>> GetObjectRecordsAsync(int limit, DateTime fromTime, Order order, int? fromId = null, string objectClass = "any", bool withThumbnail = true, string sourceFilter = null,
			WatchlistFilter watchlistFilter = WatchlistFilter.Any)
		{
			return ReadRecordsAsync(limit, fromTime, order, NSurveillanceModalityType.VehiclesAndHumans, fromId, withThumbnail, sourceFilter, objectClass, watchlistFilter: watchlistFilter);
		}

		public Task<List<Record>> GetLicenseRecordsAsync(int limit, DateTime fromTime, Order order, int? fromId = null, bool withThumbnail = true, string sourceFilter = null,
			WatchlistFilter watchlistFilter = WatchlistFilter.Any)
		{
			return ReadRecordsAsync(limit, fromTime, order, NSurveillanceModalityType.LicensePlateRecognition, fromId, withThumbnail, sourceFilter, watchlistFilter: watchlistFilter);
		}

		public Task<List<Record>> GetFaceRecordsAsync(int limit, DateTime fromTime, Order order, int? fromId = null, bool withThumbnail = true, string sourceFilter = null,
			WatchlistFilter watchlistFilter = WatchlistFilter.Any)
		{
			return ReadRecordsAsync(limit, fromTime, order, NSurveillanceModalityType.Faces, fromId, withThumbnail, sourceFilter, watchlistFilter: watchlistFilter);
		}

		public Task<List<Record>> GetRecordsAsync(int limit, DateTime fromTime, Order order, int? fromId = null, bool withThumbnails = true, string sourceFilter = null,
			WatchlistFilter watchlistFilter = WatchlistFilter.Any)
		{
			return ReadRecordsAsync(limit, fromTime, order, NSurveillanceModalityType.Faces | NSurveillanceModalityType.LicensePlateRecognition | NSurveillanceModalityType.VehiclesAndHumans,
				fromId, withThumbnails, sourceFilter, watchlistFilter: watchlistFilter);
		}

		public Task<List<Record>> GetObjectsWithFacesAsync(int limit, DateTime fromTime, Order order, int? fromId = null, bool withThumbnails = true, string sourceFilter = null,
			WatchlistFilter watchlistFilter = WatchlistFilter.Any)
		{
			return ReadRecordsAsync(limit, fromTime, order, NSurveillanceModalityType.VehiclesAndHumans | NSurveillanceModalityType.Faces, fromId, withThumbnails, sourceFilter, watchlistFilter: watchlistFilter);
		}

		public async Task<List<RecordSource>> GetUniqueSources()
		{
			var list = new List<RecordSource>();
			DbDataReader reader = null;
			string query = $@"SELECT source, isVideoSource FROM {RecordsTable} GROUP BY source";
			using (var cmd = new SQLiteCommand(query, _sqliteConnection))
			{
				try
				{
					reader = await cmd.ExecuteReaderAsync();
					while (await reader.ReadAsync())
					{
						var value = new RecordSource(reader.GetString(0), reader.GetBoolean(1));
						list.Add(value);
					}
				}
				finally
				{
					reader?.Close();
				}
			}

			return list;
		}

		#endregion

		#region Public static methods

		public static void CheckCreateDb(string fileName)
		{
			if (!File.Exists(fileName))
			{
				SQLiteConnection.CreateFile(fileName);
			}

			using (var connection = new SQLiteConnection("Version=3;New=True;Compress=False;foreign keys=true;Data Source=" + fileName))
			{
				try
				{
					connection.Open();
					CreateRecordsTable(connection);
					CreateIndices(connection);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Could not create database tables, reason: {ex.Message}");
				}
			}
		}

		#endregion

		#region Private static methods

		private static void CreateRecordsTable(SQLiteConnection connection)
		{
			string query =
				$@"CREATE TABLE IF NOT EXISTS {RecordsTable} (
					[id] INTEGER PRIMARY KEY,
					[image] IMAGE,
					[timestamp] TIMESTAMP,
					[videoOffset] INTEGER,
					[isVideoSource] BOOL,
					[source] TEXT,
					[data] TEXT,
					[car] REAL, [person] REAL, [bus] REAL, [truck] REAL, [bike] REAL,
					[objectThumbnail] IMAGE,
					[lpThumbnail] IMAGE,
					[faceThumbnail] IMAGE,
					[inWatchlist] BOOL
				)";

			using (var cmd = new SQLiteCommand(query, connection))
			{
				cmd.ExecuteNonQuery();
			}
		}

		private static void CreateIndices(SQLiteConnection connection)
		{
			string query = $"CREATE INDEX IF NOT EXISTS idx_sources ON {RecordsTable} (source)";
			using (var cmd = new SQLiteCommand(query, connection))
			{
				cmd.ExecuteNonQuery();
			}

			query = $"CREATE INDEX IF NOT EXISTS idx_timespan ON {RecordsTable} (timestamp)";
			using (var cmd = new SQLiteCommand(query, connection))
			{
				cmd.ExecuteNonQuery();
			}
		}

		private static NBuffer SaveBitmap(Bitmap bmp)
		{
			if (bmp != null)
			{
				using (var image = NImage.FromBitmap(bmp))
				{
					return image.Save(NImageFormat.Jpeg);
				}
			}
			return null;
		}

		private static NBuffer SaveImage(NImage image) => image?.Save(NImageFormat.Jpeg);

		#endregion

		#region Private methods

		private async Task<List<Record>> ReadRecordsAsync(int limit, DateTime fromTime, Order order, NSurveillanceModalityType modalities, int? fromId = null, bool withThumbnails = true,
			string sourceFilter = null, string objectClass = "any", WatchlistFilter watchlistFilter = WatchlistFilter.Any)
		{
			string BuildQuery()
			{
				var fields = withThumbnails ? ReadFieldsWithImages : ReadFieldsWithoutImages;
				var sb = new StringBuilder();
				sb.Append($@"SELECT {fields} FROM {RecordsTable}
							WHERE timestamp >= '{fromTime.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' ");

				if (modalities != (NSurveillanceModalityType.Faces | NSurveillanceModalityType.VehiclesAndHumans | NSurveillanceModalityType.LicensePlateRecognition))
				{
					if (modalities.HasFlag(NSurveillanceModalityType.Faces))
						sb.Append(" AND faceThumbnail IS NOT NULL ");
					if (modalities.HasFlag(NSurveillanceModalityType.LicensePlateRecognition))
						sb.Append(" AND lpThumbnail IS NOT NULL ");
					if (modalities.HasFlag(NSurveillanceModalityType.VehiclesAndHumans))
						sb.Append(" AND objectThumbnail IS NOT NULL ");
				}
				if (fromId != null)
					sb.Append(order == Order.Descending ? $"AND id < {fromId} " : $"AND id > {fromId} ");
				if (!string.IsNullOrEmpty(sourceFilter))
					sb.Append($" AND source = '{sourceFilter}'");
				if (!string.IsNullOrEmpty(objectClass) && objectClass != "any")
					sb.Append($" AND {objectClass} >= 0.50 ");

				if (watchlistFilter != WatchlistFilter.Any)
					sb.Append($" AND inWatchlist = {watchlistFilter == WatchlistFilter.InWatchlist} ");

				sb.Append("ORDER BY id " + (order == Order.Descending ? "DESC" : "ASC"));
				sb.Append($" LIMIT {limit}");

				return sb.ToString();
			}

			DbDataReader reader = null;
			var records = new List<Record>();

			string query = BuildQuery();
			using (SQLiteCommand cmd = new SQLiteCommand(query, _sqliteConnection))
			{
				try
				{
					reader = await cmd.ExecuteReaderAsync();
					while (reader.Read())
					{
						int ordinal = 0;
						int id = reader.GetInt32(ordinal++);
						NImage image = null;
						if (withThumbnails)
						{
							// Uncomment to read full image, if it was saved
							//image = !reader.IsDBNull(1) ? ReadNImage(reader, 1) : null;
							ordinal++;
						}
						DateTime timestamp = reader.GetDateTime(ordinal++);
						TimeSpan videoTimeStamp = TimeSpan.FromTicks(reader.GetInt64(ordinal++));
						bool isVideo = reader.GetBoolean(ordinal++);
						string source = reader.GetString(ordinal++);

						string dataString = reader.GetString(ordinal++);
						var data = JsonConvert.DeserializeObject<DataType>(dataString);

						if (!modalities.HasFlag(NSurveillanceModalityType.VehiclesAndHumans))
							data.Object = null;
						if (!modalities.HasFlag(NSurveillanceModalityType.LicensePlateRecognition))
							data.Lpr = null;
						if (!modalities.HasFlag(NSurveillanceModalityType.Faces))
							data.Face = null;

						if (withThumbnails)
						{
							if (modalities.HasFlag(NSurveillanceModalityType.VehiclesAndHumans) && data.Object != null)
								data.Object.Thumbnail = ReadImage(reader, ordinal);
							ordinal++;

							if (modalities.HasFlag(NSurveillanceModalityType.LicensePlateRecognition) && data.Lpr != null)
								data.Lpr.Thumbnail = ReadImage(reader, ordinal);
							ordinal++;

							if (modalities.HasFlag(NSurveillanceModalityType.Faces) && data.Face != null)
								data.Face.Thumbnail = ReadImage(reader, ordinal);
							ordinal++;
						}
						else
						{
						}

						records.Add(new Record(id, timestamp, videoTimeStamp, isVideo, source, data.Object, data.Lpr, data.Face)
						{
							Image = image
						});
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Could not select events, reason: {ex.Message}");
				}
				finally
				{
					reader?.Close();
				}
			}
			return records;
		}

		private Bitmap ReadImage(DbDataReader reader, int ordinal)
		{
			if (!reader.IsDBNull(ordinal))
			{
				long fieldSize = reader.GetBytes(ordinal, 0, null, 0, 0);
				byte[] bytes = new byte[fieldSize];
				reader.GetBytes(ordinal, 0, bytes, 0, (int)fieldSize);
				using (var image = NImage.FromMemory(bytes))
				{
					return image.ToBitmap();
				}
			}
			return null;
		}

		#endregion
	}
}
