using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColumnWidth
{
	internal class ColWidth
	{
		public string Path { get; set; } = string.Empty;

		public string Sheet { get; set; } = string.Empty;

		public ColWidth() { }

		public ColWidth(string path, string sheet)
		{
			Path = path;
			Sheet = sheet;
		}

		public void ColumnWidth1()
		{
			using (var workbook = new XLWorkbook())
			{
				var workSheet = workbook.Worksheets.Add(Sheet);
				workSheet.Cell(2, 2).Value = $"Column width = 30";
				workSheet.Column(2).Width = 30;

				workbook.SaveAs(Path);
			}
		}
	}
}
