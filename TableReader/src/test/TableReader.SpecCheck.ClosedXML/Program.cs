using System;
using System.IO;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableReader.ClosedXML;
using TableReader.Interface;
using System.Data;
using System.Diagnostics;

namespace TableReader.SpecCheck.ClosedXML
{
	class Program
	{
		static void Main(string[] args)
		{
			string testFilePath = @".\..\..\..\TestData\TableReader_SpecCheck.xlsx";
			long totalTime = 0;
			for (int index = 0; index < 40; index++)
			{
				using (var stream = new FileStream(testFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					var stopWatch = new Stopwatch();
					ITableReader reader = new ExcelTableReader(stream, "Read_test_002");
					stopWatch.Start();
					DataTable table = reader.Read("TestTable_001");
					stopWatch.Stop();
					Console.WriteLine($"time({index + 1}) = {stopWatch.ElapsedMilliseconds} ms");
					totalTime += stopWatch.ElapsedMilliseconds;
				}
			}
			Console.Write($"Average = {totalTime / 100} ms");
			return;
		}
	}
}
