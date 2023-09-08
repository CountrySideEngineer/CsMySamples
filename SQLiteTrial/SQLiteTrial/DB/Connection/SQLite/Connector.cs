using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

		private readonly string _dbPath;

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
			_connection.Close();
		}

		/// <summary>
		/// Dispose connection.
		/// </summary>
		public void Dispose()
		{
			Disconnect();

			_connection.Dispose();
			_transaction.Dispose();

			_transaction = null;
		}

		public void ExecuteNonQuery(string query)
		{
			throw new NotImplementedException();
		}

		public void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
		{
			throw new NotImplementedException();
		}

		public SQLiteDataReader ExecuteQuery(string query)
		{
			throw new NotImplementedException();
		}

		public SQLiteDataReader ExecuteQuery(string query, Dictionary<string, object> parameters)
		{
			throw new NotImplementedException();
		}
	}
}
