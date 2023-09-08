using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.Connection
{
	internal interface IDBConnector<Reader> : IDisposable
	{
		Reader ExecuteQuery(string query);
		Reader ExecuteQuery(string query, Dictionary<string, object> parameters);

		void ExecuteNonQuery(string query);
		void ExecuteNonQuery(string query, Dictionary<string, object> parameters);

		void Initialize();

		string SetupConnectionString();

		void Disconnect();

		void BeginTransaction();
		void Commit();
		void RollBack();
	}
}
