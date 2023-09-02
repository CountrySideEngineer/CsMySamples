using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetGridLines
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var gridLines = new SheetGridLines()
			{
				Path = @"./ClosedXml_GridLines1.xlsx",
				Sheet = "GridLinesSample"
			};
			gridLines.GridLines1();

			gridLines.Path = @"./ClosedXml_GridLines2.xlsx";
			gridLines.GridLines2();
		}
	}
}
