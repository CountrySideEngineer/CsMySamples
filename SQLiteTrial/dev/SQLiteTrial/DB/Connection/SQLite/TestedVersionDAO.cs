using SQLiteTrial.DB.DTO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.Connection.SQLite
{
	public class TestedVersionDAO : IDbAccess
	{
		public object SelectAll()
		{
			List<TestedVersionDTO> testedVersions = null;
			string query = "SELECT * FROM testers";
			using (var connection = new Connector())
			using (SQLiteDataReader reader = connection.ExecuteQuery(query))
			{
				testedVersions = new List<TestedVersionDTO>();
				while (reader.Read())
				{
					int id = Convert.ToInt32(reader["ID"]);
					string verCode = reader["version_code"].ToString();
					int preId = Convert.ToInt32(reader["preversion_id"]);
					DateTime createdAt = DateTime.Parse(reader["created_at"].ToString());
					DateTime updatedAt = DateTime.Parse(reader["updated_at"].ToString());
					var testedVersion = new TestedVersionDTO()
					{
						ID = id,
						VersionCode = verCode,
						PreVersionID = preId,
						CreatedAt = createdAt,
						UpdateAt = updatedAt
					};
					testedVersions.Add(testedVersion);
				}
				reader.Close();
			}
			return testedVersions;
		}

		public object Delete(object dto)
		{
			throw new NotImplementedException();
		}

		public object Insert(object dto)
		{
			throw new NotImplementedException();
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
