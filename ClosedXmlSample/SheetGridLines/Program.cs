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
				Path = @"./ClosedXml_GridLines.xlsx",
				Sheet = "GridLinesSample"
			};
			gridLines.GridLines1();
		}
	}
}
