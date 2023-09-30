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


            var records = new List<SampleDTO>();
            for (int index = 0; index < 300; index++)
            {
                var reccord = new SampleDTO()
                {
                    Column1 = $"col1_{index}",
                    Column2 = $"col2_{index}",
                    Column3 = $"col3_{index}",
                    Column4 = $"col4_{index}"
                };
                records.Add(reccord);
            }

            var sw = new System.Diagnostics.Stopwatch();

            SampleDAO dao = new MultiSampleDAO();
            sw.Start();
            dao.Insert(records);
            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            Console.WriteLine($"　{ts}");
            Console.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
            Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

            records = new List<SampleDTO>();
            for (int index = 0; index < 10000; index++)
            {
                var reccord = new SampleDTO()
                {
                    Column1 = $"col1_1_{index}",
                    Column2 = $"col1_2_{index}",
                    Column3 = $"col1_3_{index}",
                    Column4 = $"col1_4_{index}"
                };
                records.Add(reccord);
            }
            dao = new SampleDAO();
            sw.Start();
            foreach (var record in records)
            {
                dao.Insert(record);
            }
            sw.Stop();

            ts = sw.Elapsed;
            Console.WriteLine($"　{ts}");
            Console.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
            Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

            return;
        }
    }
}
