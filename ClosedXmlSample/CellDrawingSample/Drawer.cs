using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellDrawingSample
{
	internal class Drawer
	{
		/// <summary>
		/// Sample file output path.
		/// </summary>
		public string Path { get; set; } = string.Empty;

		public string Sheet { get; set; } = string.Empty;
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Drawer()
		{
			Path = string.Empty;
			Sheet = string.Empty;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="sheet"></param>
		public Drawer(string path, string sheet = "")
		{
			Path = path;
			Sheet = sheet;
		}

		public void Draw()
		{
			var workbook = new XLWorkbook();
			var worksheet = workbook.Worksheets.Add(Sheet);

			worksheet.Cell(1, 1).Value = "Hello, ClosedXml";

			workbook.SaveAs(Path);
		}
	}
}
