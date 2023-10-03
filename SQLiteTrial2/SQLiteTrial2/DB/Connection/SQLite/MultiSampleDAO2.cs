using SQLiteTrial2.DB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial2.DB.Connection.SQLite
{
	internal class MultiSampleDAO2 : SampleDAO
	{
		public override object Insert(object dto)
		{
			IEnumerable<SampleDTO> sampleDtos = (IEnumerable<SampleDTO>)dto;
			string query = string.Empty;
			for (int index = 0; index < sampleDtos.Count(); index++)
			{
				var item = sampleDtos.ElementAt(index);
				string queryPart =
					"INSERT OR IGNORE INTO sample_datas " +
					"(col1, col2, col3, col4) " +
					"VALUES " +
					$"(\'{item.Column1}\', \'{item.Column2}\', \'{item.Column3}\', \'{item.Column4}\');";
				query += queryPart;
			}
			using (var connection = new Connector())
			{
				connection.BeginTransaction();

				var sw = new System.Diagnostics.Stopwatch();
				sw.Start();

				int count = connection.ExecuteNonQuery(query);

				sw.Stop();
				TimeSpan ts = sw.Elapsed;
				Console.WriteLine($"　{ts}");
				Console.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
				Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

				connection.Commit();

				return count;
			}
		}
	}
}
