using SQLiteTrial.DB.DTO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.Connection.SQLite
{
	public class TestersDAO : IDbAccess
	{
		public object SelectAll()
		{
			string query = "SELECT * FROM testers";
			using (var connection = new Connector())
			using (SQLiteDataReader reader = connection.ExecuteQuery(query))
			{
				var testers = new List<TestersDTO>();
				while (reader.Read())
				{
					int id = Convert.ToInt32(reader["ID"]);
					string code = reader["tester_code"].ToString();
					string company = reader["company"].ToString();
					string section = reader["section"].ToString();
					string name = reader["name"].ToString();
					DateTime createdAt = DateTime.Parse(reader["created_at"].ToString());
					DateTime updatedAt = DateTime.Parse(reader["updated_at"].ToString());
					var tester = new TestersDTO()
					{
						ID = id,
						TesterCode = code,
						Company = company,
						Section = section,
						Name = name,
						CreatedAt = createdAt,
						UpdateAt = updatedAt
					};
					testers.Add(tester);
				}
				reader.Close();

				return testers;
			}
		}

		public object Delete(object dto)
		{
			throw new NotImplementedException();
		}

		public object Insert(object dto)
		{
			TestersDTO testerDto = (TestersDTO)dto;
			string query =
				"INSERT OR IGNORE INTO testers " +
				"(tester_code, company, section, name) " +
				"VALUES " +
				"(@tester_code, @company, @section, @name);";
			var parameters = new Dictionary<string, object>();
			parameters.Add("@tester_code", testerDto.TesterCode);
			parameters.Add("@company", testerDto.Company);
			parameters.Add("@section", testerDto.Section);
			parameters.Add("@name", testerDto.Name);
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
