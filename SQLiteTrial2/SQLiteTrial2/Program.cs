using SQLiteTrial2.DB.Connection.SQLite;
using SQLiteTrial2.DB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial2
{
    internal class Program
    {
        static void Main(string[] args)
        {
			var records2 = new List<SampleDTO>();
			for (int index = 0; index < 10000; index++)
			{
				var reccord = new SampleDTO()
				{
					Column1 = $"col1_3_{index}",
					Column2 = $"col2_3_{index}",
					Column3 = $"col3_3_{index}",
					Column4 = $"col4_3_{index}"
				};
				records2.Add(reccord);
			}

			//var sw = new System.Diagnostics.Stopwatch();
			SampleDAO dao = new MultiSampleDAO2();
			//sw.Start();
			dao.Insert(records2);
			//sw.Stop();

			//TimeSpan ts = sw.Elapsed;
			//Console.WriteLine($"　{ts}");
			//Console.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
			//Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

			var records3 = new List<SampleDTO>();
			for (int index = 0; index < 10000; index++)
			{
				var reccord = new SampleDTO()
				{
					Column1 = $"col1_4_{index}",
					Column2 = $"col2_4_{index}",
					Column3 = $"col3_4_{index}",
					Column4 = $"col4_4_{index}"
				};
				records3.Add(reccord);
			}

			//sw = new System.Diagnostics.Stopwatch();
			dao = new MultiSampleDAO3();
			//sw.Start();
			dao.Insert(records2);
			//sw.Stop();

			//ts = sw.Elapsed;
			//Console.WriteLine($"　{ts}");
			//Console.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
			//Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");


			//var records = new List<SampleDTO>();
			//         for (int index = 0; index < 1000; index++)
			//         {
			//             var reccord = new SampleDTO()
			//             {
			//                 Column1 = $"col1_1_{index}",
			//                 Column2 = $"col2_1_{index}",
			//                 Column3 = $"col3_1_{index}",
			//                 Column4 = $"col4_1_{index}"
			//             };
			//             records.Add(reccord);
			//         }

			//         var sw = new System.Diagnostics.Stopwatch();

			//         SampleDAO dao = new MultiSampleDAO();
			//         sw.Start();
			//         dao.Insert(records);
			//         sw.Stop();

			//         TimeSpan ts = sw.Elapsed;
			//         Console.WriteLine($"　{ts}");
			//         Console.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
			//         Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

			//         records = new List<SampleDTO>();
			//         for (int index = 0; index < 1000; index++)
			//         {
			//             var reccord = new SampleDTO()
			//             {
			//                 Column1 = $"col1_2_{index}",
			//                 Column2 = $"col2_2_{index}",
			//                 Column3 = $"col3_2_{index}",
			//                 Column4 = $"col4_2_{index}"
			//             };
			//             records.Add(reccord);
			//         }
			//         dao = new SampleDAO();
			//         sw.Start();
			//         foreach (var record in records)
			//         {
			//             dao.Insert(record);
			//         }
			//         sw.Stop();

			//         ts = sw.Elapsed;
			//         Console.WriteLine($"　{ts}");
			//         Console.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
			//         Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

			return;
        }
    }
}
