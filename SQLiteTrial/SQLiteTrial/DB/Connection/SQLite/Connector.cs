using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.Connection.SQLite
{
	public class Connector : IDBConnector<SQLiteDataReader>
	{
		protected SQLiteConnection _connection;
		protected SQLiteTransaction _transaction;
		protected string _connectionString;

		private readonly string _dbPath = @".\..\SQLiteSampleDataBase.db";

		/// <summary>
		/// Default constructor
		/// </summary>
		public Connector()
		{
			Initialize();
		}

		public void Initialize()
		{
			string connectString = SetupConnectionString();

			_connection = new SQLiteConnection(connectString);
			_connection.Open();
		}

		/// <summary>
		/// Setup parameter string used when connecting 
		/// </summary>
		/// <returns>Parameter string to be used when connecting database.</returns>
		public string SetupConnectionString()
		{
			string connString = $"Data source={_dbPath}";
			return connString;
		}

		/// <summary>
		/// Begin start transaction control.
		/// </summary>
		public void BeginTransaction()
		{
			_transaction = _connection.BeginTransaction();
		}

		/// <summary>
		/// Commit the transaction.
		/// </summary>
		public void Commit()
		{
			if (null != _transaction.Connection)
			{
				_transaction.Commit();
				Dispose();
			}
		}

		/// <summary>
		/// Execute rollback.
		/// </summary>
		public void RollBack()
		{
			if (null != _transaction.Connection)
			{
				_transaction.Rollback();
				Dispose();
			}
		}

		/// <summary>
		/// Disconnect from database.
		/// </summary>
		public void Disconnect()
		{
			try
			{
				_connection.Close();
			}
			catch (ObjectDisposedException)
			{
				//If the connection has alredy been disposed, ignore the exception.
			}
		}

		/// <summary>
		/// Dispose connection.
		/// </summary>
		public void Dispose()
		{
			Disconnect();

			_connection.Dispose();
			_transaction?.Dispose();

			_transaction = null;
		}

		public int ExecuteNonQuery(string query)
		{
			int count = ExecuteNonQuery(query, new Dictionary<string, object>());
			return count;
		}

		public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
		{
			using (var cmd = new SQLiteCommand())
			{
				cmd.Connection = _connection;
				cmd.Transaction = _transaction;
				foreach (var parameter in parameters)
				{
					if (0 < query.IndexOf(parameter.Key))
					{
						var sqliteParamemeter = new SQLiteParameter(parameter.Key, parameter.Value);
						cmd.Parameters.Add(sqliteParamemeter);
					}
				}
				cmd.CommandText = query;
				int count = cmd.ExecuteNonQuery();
				return count;
			}
		}

		public SQLiteDataReader ExecuteQuery(string query)
		{
			SQLiteDataReader reader = ExecuteQuery(query, new Dictionary<string, object>());
			return reader;
		}

		public SQLiteDataReader ExecuteQuery(string query, Dictionary<string, object> parameters)
		{
			using (var cmd = new SQLiteCommand())
			{
				cmd.Connection = _connection;
				cmd.Transaction = _transaction;
				foreach (var parameter in parameters)
				{
					if (0 < query.IndexOf(parameter.Key))
					{
						var sqliteParamemeter = new SQLiteParameter(parameter.Key, parameter.Value);
						cmd.Parameters.Add(sqliteParamemeter);
					}
				}
				cmd.CommandText = query;
				SQLiteDataReader reader = cmd.ExecuteReader();

				return reader;
			}
		}
	}
}
