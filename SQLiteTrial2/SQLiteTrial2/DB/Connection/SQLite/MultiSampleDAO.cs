using SQLiteTrial2.DB.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial2.DB.Connection.SQLite
{
    internal class MultiSampleDAO : SampleDAO
    {
        public override object Insert(object dto)
        {
            IEnumerable<SampleDTO> sampleDtos = (IEnumerable<SampleDTO>)dto;
            string query =
                "INSERT OR IGNORE INTO sample_datas " +
                "(col1, col2, col3, col4) " +
                "VALUES ";
            bool isTop = true;
            int index = 0;
            var parameters = new Dictionary<string, object>();
            do
            {
                if (!isTop)
                {
                    query += ", ";
                }
                string queryExt = $"(@col1_{index}, @col2_{index}, @col3_{index}, @col4_{index})";
                query += queryExt;

                var element = sampleDtos.ElementAt(index);
                parameters.Add($"@col1_{index}", element.Column1);
                parameters.Add($"@col2_{index}", element.Column2);
                parameters.Add($"@col3_{index}", element.Column3);
                parameters.Add($"@col4_{index}", element.Column4);

                isTop = false;
                index++;
            } while (index < sampleDtos.Count());
            query += ";";

            using (var connection = new Connector())
            {
                connection.BeginTransaction();

                int count = connection.ExecuteNonQuery(query, parameters);

                connection.Commit();

                return count;
            }
        }
    }
}
