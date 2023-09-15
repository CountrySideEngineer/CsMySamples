using SQLiteTrial.DB.DTO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.Connection.SQLite
{
	public class TestCaseDAO : IDbAccess
	{
		public object SelectAll()
		{
			string query = "SELECT * FROM test_cases";
			using (var connection = new Connector())
			using (SQLiteDataReader reader = connection.ExecuteQuery(query))
			{
				var testCases = new List<TestCasesDTO>();
				while (reader.Read())
				{
					int id = Convert.ToInt32(reader["ID"]);
					string code = reader["test_code"].ToString();
					string summary = reader["summary"].ToString();
					string detail = reader["detail"].ToString();
					DateTime createdAt = DateTime.Parse(reader["created_at"].ToString());
					DateTime updatedAt = DateTime.Parse(reader["updated_at"].ToString());
					var testCase = new TestCasesDTO()
					{
						ID = id,
						TestCode = code,
						Summary = summary,
						Detail = detail,
						CreatedAt = createdAt,
						UpdateAt = updatedAt
					};
					testCases.Add(testCase);
				}
				reader.Close();

				return testCases;
			}
		}

		public object Delete(object dto)
		{
			throw new NotImplementedException();
		}

		public object Insert(object dto)
		{
			TestCasesDTO testCase = (TestCasesDTO)dto;
			string query =
				"INSERT OR IGNORE INTO test_cases " +
				"(test_code, summary, detail) " +
				"VALUES " +
				"(@test_code, @summary, @detail);";
			var parameters = new Dictionary<string, object>();
			parameters.Add("@test_code", testCase.TestCode);
			parameters.Add("@summary", testCase.Summary);
			parameters.Add("@detail", testCase.Detail);
			using (var connection = new Connector())
			{
				connection.BeginTransaction();

				int count = connection.ExecuteNonQuery(query, parameters);

				connection.Commit();

				return count;
			}
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
