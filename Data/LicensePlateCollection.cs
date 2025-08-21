using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Neurotec.Samples.Data
{
	public class LicensePlateRecord
	{
		public LicensePlateRecord(string value, string owner)
		{
			Value = value;
			Owner = owner;
		}

		public string Value { get; set; }
		public string Owner { get; set; }
	}

	public class LicensePlateCollection : IEnumerable<LicensePlateRecord>
	{
		#region Private constants

		private const string TableName = "LicensePlateWatchList";

		#endregion

		#region Private fields

		private readonly SQLiteConnection _sqliteConnection;
		private readonly Dictionary<string, LicensePlateRecord> _dictionary = new Dictionary<string, LicensePlateRecord>();

		#endregion

		#region Public constructor

		public LicensePlateCollection(string dbFile)
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
				var select = new SQLiteCommand($"SELECT * FROM {TableName};", _sqliteConnection);
				var reader = select.ExecuteReader();
				while (reader.Read())
				{
					var id = reader.GetString(0);
					var owner = reader.GetString(1);
					_dictionary[id] = new LicensePlateRecord(id, owner);
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

		#region Public methods

		public void Close()
		{
			_sqliteConnection.Close();
		}

		public bool Add(string value, string owner)
		{
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException(nameof(value));

			var upper = value.Trim().ToUpperInvariant();
			if (!_dictionary.ContainsKey(upper))
			{
				WriteToDb(upper, owner);
				_dictionary[upper] = new LicensePlateRecord(upper, owner);
				return true;
			}
			return false;
		}

		public bool Contains(string value)
		{
			return _dictionary.ContainsKey(value?.Trim().ToUpperInvariant() ?? string.Empty);
		}

		public void Delete(string value)
		{
			value = value?.Trim().ToUpperInvariant() ?? string.Empty;
			using (var deleteCommand = new SQLiteCommand($"DELETE FROM {TableName} WHERE id=@id", _sqliteConnection))
			{
				deleteCommand.Parameters.AddWithValue("@id", value);
				deleteCommand.ExecuteNonQuery();
				_dictionary.Remove(value);
			}
		}

		public int GetCount()
		{
			return _dictionary.Count;
		}

		public void Clear()
		{
			_dictionary.Clear();
			using (var deleteAll = new SQLiteCommand($"DELETE FROM {TableName}", _sqliteConnection))
			{
				deleteAll.ExecuteNonQuery();
			}
		}

		public LicensePlateRecord this[string value]
		{
			get
			{
				return _dictionary.TryGetValue(value, out var result) ? result : null;
			}
		}

		#endregion

		#region Private methods

		private void WriteToDb(string value, string owner)
		{
			try
			{
				string cmdstr = $"INSERT INTO {TableName} (id, owner) VALUES (@id, @owner);";
				using (var insert = new SQLiteCommand(cmdstr, _sqliteConnection))
				{
					insert.Parameters.AddWithValue("@id", value);
					insert.Parameters.AddWithValue("@owner", owner);
					insert.ExecuteNonQuery();
				}
			}
			catch (InvalidOperationException ex)
			{
				MessageBox.Show(string.Format("Failed to insert record into DB:\n{0}", ex.Message));
			}
		}

		#endregion

		#region Private static methods

		private static void CreateTable(SQLiteConnection conn)
		{
			using (var cmd = new SQLiteCommand($"CREATE TABLE {TableName} ([id] TEXT PRIMARY KEY, [owner] TEXT)", conn))
			{
				cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region IEnumerable

		public IEnumerator<LicensePlateRecord> GetEnumerator()
		{
			return _dictionary.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _dictionary.Values.GetEnumerator();
		}

		#endregion

	}
}
