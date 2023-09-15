using SQLiteTrial.DB.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.Connection.SQLite
{
	public class TestResultCodesDAO : IDbAccess
	{
		public object SelectAll()
		{
			string query = "SELECT * FROM test_result_codes";
			using (var connection = new Connector())
			using (SQLiteDataReader reader = connection.ExecuteQuery(query))
			{
				var codes = new List<TestResultCodesDTO>();
				while (reader.Read())
				{
					int id = Convert.ToInt32(reader["ID"]);
					string text = reader["result_text"].ToString();
					DateTime createdAt = DateTime.Parse(reader["created_at"].ToString());
					DateTime updatedAt = DateTime.Parse(reader["updated_at"].ToString());
					var code = new TestResultCodesDTO()
					{
						ID = id,
						ResultText = text,
						CreatedAt = createdAt,
						UpdateAt = updatedAt
					};
					codes.Add(code);
				}
				reader.Close();

				return codes;
			}
		}

		public object Delete(object dto)
		{
			throw new NotImplementedException();
		}

		public object Insert(object dto)
		{
			TestResultCodesDTO testResultCode = (TestResultCodesDTO)dto;
			string query =
				"INSERT OR IGNORE INTO test_result_codes " +
				"(result_text) " +
				"VALUES " +
				"(@test_result_code);";
			var parameters = new Dictionary<string, object>();
			parameters.Add("@test_result_code", testResultCode.ResultText);
			int count = 0;
			using (var connection = new Connector())
			{
				connection.BeginTransaction();

				count = connection.ExecuteNonQuery(query, parameters);

				connection.Commit();
			}
			return count;
		}

		public object Select(object dto)
		{
			throw new NotImplementedException();
		}

		public object Update(object dto)
		{
			throw new NotImplementedException();
		}
	}
}
