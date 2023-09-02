using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetGridLines
{
	internal class SheetGridLines
	{
		public string Path { get; set; }

		public string Sheet { get; set; }

		public SheetGridLines() { }

		public SheetGridLines(string path, string sheet)
		{
			Path = path;
			Sheet = sheet;
		}

		public void GridLines1()
		{
			using (var workbook = new XLWorkbook())
			{
				var workSheet = workbook.Worksheets.Add(Sheet);
				workSheet.ShowGridLines = false;
				workSheet.Cell(2, 2).Value = "ShowGridLines = false";

				workbook.SaveAs(Path);
			}
		}

		public void GridLines2()
		{
			using (var workbook = new XLWorkbook())
			{
				var workSheet = workbook.Worksheets.Add(Sheet);
				workSheet.ShowGridLines = true;
				workSheet.Cell(2, 2).Value = "ShowGridLines = true";

				workbook.SaveAs(Path);
			}
		}
	}
}
