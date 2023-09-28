using SQLiteTrial2.DB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial2.DB.Connection.SQLite
{
    internal class SampleDAO : IDBAccess
    {
        public object Delete(object dto)
        {
            throw new NotImplementedException();
        }

        public virtual object Insert(object dto)
        {
            SampleDTO sampleDto = (SampleDTO)dto;
            string query =
                "INSERT OR IGNORE INTO sample_datas " +
                "(col1, col2, col3, col4) " +
                "VALUES " +
                "(@col1, @col2, @col3, @col4);";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@col1", sampleDto.Column1);
            parameters.Add("@col2", sampleDto.Column2);
            parameters.Add("@col3", sampleDto.Column3);
            parameters.Add("@col4", sampleDto.Column4);

            using (var connection = new Connector())
            {
                connection.BeginTransaction();

                int count = connection.ExecuteNonQuery(query, parameters);

                connection.Commit();

                return count;
            }
        }

        public virtual object Select(object dto)
        {
            throw new NotImplementedException();
        }

        public object SelectAll()
        {
            throw new NotImplementedException();
        }

        public object Update(object dto)
        {
            throw new NotImplementedException();
        }
    }
}
