using SQLiteTrial2.DB.DTO;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial2.DB.Connection.SQLite
{
	internal class MultiSampleDAO3 : SampleDAO
	{
		public override object Insert(object dto)
		{
			IEnumerable<SampleDTO> sampleDtos = (IEnumerable<SampleDTO>)dto;
			string queryPre =
					"INSERT OR IGNORE INTO sample_datas " +
					"(col1, col2, col3, col4) " +
					"VALUES ";
			bool isTop = true;
			string queryValue = string.Empty;
			for (int index = 0; index < sampleDtos.Count(); index++)
			{
				if (!isTop)
				{
					queryValue += ", ";
				}
				var item = sampleDtos.ElementAt(index);
				string queryPart =
					$"(\'{item.Column1}\', \'{item.Column2}\', \'{item.Column3}\', \'{item.Column4}\')";
				queryValue += queryPart;

				isTop = false;
			}
			string query = queryPre + queryValue + ";";
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
