using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellDrawingSample
{
	internal class DrawRuledLine
	{
		public string Path { get; set; }

		public string Sheet { get; set; }

		public DrawRuledLine()
		{
			Path = string.Empty;
			Sheet = string.Empty;
		}

		public DrawRuledLine(string path, string sheet)
		{
			Path = path;
			Sheet = sheet;

		}

		public void Draw1()
		{
			var workbook = new XLWorkbook();
			var workSheet = workbook.Worksheets.Add(Sheet);

			//セルの周りに標準の罫線を引
			workSheet.Cell(2, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.DashDot)
				.Border.SetRightBorder(XLBorderStyleValues.DashDot)
				.Border.SetBottomBorder(XLBorderStyleValues.DashDot)
				.Border.SetLeftBorder(XLBorderStyleValues.DashDot);
			workSheet.Cell(2, 2).Value = "XLBorderStyleValues.DashDot";

			workSheet.Cell(4, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.DashDotDot)
				.Border.SetRightBorder(XLBorderStyleValues.DashDotDot)
				.Border.SetBottomBorder(XLBorderStyleValues.DashDotDot)
				.Border.SetLeftBorder(XLBorderStyleValues.DashDotDot);
			workSheet.Cell(4, 2).Value = "XLBorderStyleValues.DashDotDot";

			workSheet.Cell(6, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.Dashed)
				.Border.SetRightBorder(XLBorderStyleValues.Dashed)
				.Border.SetBottomBorder(XLBorderStyleValues.Dashed)
				.Border.SetLeftBorder(XLBorderStyleValues.Dashed);
			workSheet.Cell(6, 2).Value = "XLBorderStyleValues.Dashed";

			workSheet.Cell(8, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.Dotted)
				.Border.SetRightBorder(XLBorderStyleValues.Dotted)
				.Border.SetBottomBorder(XLBorderStyleValues.Dotted)
				.Border.SetLeftBorder(XLBorderStyleValues.Dotted);
			workSheet.Cell(8, 2).Value = "XLBorderStyleValues.Dotted";

			workSheet.Cell(10, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.Double)
				.Border.SetRightBorder(XLBorderStyleValues.Double)
				.Border.SetBottomBorder(XLBorderStyleValues.Double)
				.Border.SetLeftBorder(XLBorderStyleValues.Double);
			workSheet.Cell(10, 2).Value = "XLBorderStyleValues.Double";

			workSheet.Cell(12, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.Hair)
				.Border.SetRightBorder(XLBorderStyleValues.Hair)
				.Border.SetBottomBorder(XLBorderStyleValues.Hair)
				.Border.SetLeftBorder(XLBorderStyleValues.Hair);
			workSheet.Cell(12, 2).Value = "XLBorderStyleValues.Hair";

			workSheet.Cell(14, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.Medium)
				.Border.SetRightBorder(XLBorderStyleValues.Medium)
				.Border.SetBottomBorder(XLBorderStyleValues.Medium)
				.Border.SetLeftBorder(XLBorderStyleValues.Medium);
			workSheet.Cell(14, 2).Value = "XLBorderStyleValues.Medium";

			workSheet.Cell(16, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.MediumDashDot)
				.Border.SetRightBorder(XLBorderStyleValues.MediumDashDot)
				.Border.SetBottomBorder(XLBorderStyleValues.MediumDashDot)
				.Border.SetLeftBorder(XLBorderStyleValues.MediumDashDot);
			workSheet.Cell(16, 2).Value = "XLBorderStyleValues.MediumDashDot";

			workSheet.Cell(18, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.MediumDashDotDot)
				.Border.SetRightBorder(XLBorderStyleValues.MediumDashDotDot)
				.Border.SetBottomBorder(XLBorderStyleValues.MediumDashDotDot)
				.Border.SetLeftBorder(XLBorderStyleValues.MediumDashDotDot);
			workSheet.Cell(18, 2).Value = "XLBorderStyleValues.MediumDashDotDot";

			workSheet.Cell(20, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.MediumDashed)
				.Border.SetRightBorder(XLBorderStyleValues.MediumDashed)
				.Border.SetBottomBorder(XLBorderStyleValues.MediumDashed)
				.Border.SetLeftBorder(XLBorderStyleValues.MediumDashed);
			workSheet.Cell(20, 2).Value = "XLBorderStyleValues.MediumDashed";

			workSheet.Cell(22, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.None)
				.Border.SetRightBorder(XLBorderStyleValues.None)
				.Border.SetBottomBorder(XLBorderStyleValues.None)
				.Border.SetLeftBorder(XLBorderStyleValues.None);
			workSheet.Cell(22, 2).Value = "XLBorderStyleValues.None";

			workSheet.Cell(24, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.SlantDashDot)
				.Border.SetRightBorder(XLBorderStyleValues.SlantDashDot)
				.Border.SetBottomBorder(XLBorderStyleValues.SlantDashDot)
				.Border.SetLeftBorder(XLBorderStyleValues.SlantDashDot);
			workSheet.Cell(24, 2).Value = "XLBorderStyleValues.SlantDashDot";

			workSheet.Cell(26, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.Thick)
				.Border.SetRightBorder(XLBorderStyleValues.Thick)
				.Border.SetBottomBorder(XLBorderStyleValues.Thick)
				.Border.SetLeftBorder(XLBorderStyleValues.Thick);
			workSheet.Cell(26, 2).Value = "XLBorderStyleValues.Thick";

			workSheet.Cell(28, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.Thin)
				.Border.SetRightBorder(XLBorderStyleValues.Thin)
				.Border.SetBottomBorder(XLBorderStyleValues.Thin)
				.Border.SetLeftBorder(XLBorderStyleValues.Thin);
			workSheet.Cell(28, 2).Value = "XLBorderStyleValues.Thin";

			workbook.SaveAs(Path);
		}

		public void DrawEx()
		{
			var workbook = new XLWorkbook();
			var workSheet = workbook.Worksheets.Add(Sheet);

			//セルの周りに標準の罫線を引
			workSheet.Cell(2, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.DashDot)
				.Border.SetRightBorder(XLBorderStyleValues.DashDot)
				.Border.SetBottomBorder(XLBorderStyleValues.DashDot)
				.Border.SetLeftBorder(XLBorderStyleValues.DashDot);
			workSheet.Cell(2, 2).Value = "XLBorderStyleValues.DashDot";

			workSheet.Cell(3, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.DashDotDot)
				.Border.SetRightBorder(XLBorderStyleValues.DashDotDot)
				.Border.SetBottomBorder(XLBorderStyleValues.DashDotDot)
				.Border.SetLeftBorder(XLBorderStyleValues.DashDotDot);
			workSheet.Cell(3, 2).Value = "XLBorderStyleValues.DashDotDot";

			workSheet.Cell(4, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.Dashed)
				.Border.SetRightBorder(XLBorderStyleValues.Dashed)
				.Border.SetBottomBorder(XLBorderStyleValues.Dashed)
				.Border.SetLeftBorder(XLBorderStyleValues.Dashed);
			workSheet.Cell(4, 2).Value = "XLBorderStyleValues.Dashed";

			workSheet.Cell(5, 2).Style
				.Border.SetTopBorder(XLBorderStyleValues.Dotted)
				.Border.SetRightBorder(XLBorderStyleValues.Dotted)
				.Border.SetBottomBorder(XLBorderStyleValues.Dotted)
				.Border.SetLeftBorder(XLBorderStyleValues.Dotted);
			workSheet.Cell(5, 2).Value = "XLBorderStyleValues.Dotted";

			workbook.SaveAs(Path);

			Console.WriteLine($"workSheet.Cell(2, 2).Style.Border.BottomBorder = {workSheet.Cell(2, 2).Style.Border.BottomBorder}");
			Console.WriteLine($"workSheet.Cell(3, 2).Style.Border.TopBorder    = {workSheet.Cell(3, 2).Style.Border.TopBorder}");
			Console.WriteLine($"workSheet.Cell(3, 2).Style.Border.BottomBorder = {workSheet.Cell(3, 2).Style.Border.BottomBorder}");
			Console.WriteLine($"workSheet.Cell(4, 2).Style.Border.TopBorder    = {workSheet.Cell(4, 2).Style.Border.TopBorder}");
			Console.WriteLine($"workSheet.Cell(4, 2).Style.Border.BottomBorder = {workSheet.Cell(4, 2).Style.Border.BottomBorder}");
			Console.WriteLine($"workSheet.Cell(5, 2).Style.Border.TopBorder    = {workSheet.Cell(5, 2).Style.Border.TopBorder}");
		}

		public void Draw2()
		{
			var workbook = new XLWorkbook();
			var workSheet = workbook.Worksheets.Add(Sheet);

			//複数のセルに罫線を引く
			var firstCell = workSheet.Cell(2, 2);
			var lastCell = workSheet.Cell(4, 4);

			workSheet.Range(firstCell, lastCell).Style
				.Border.SetTopBorder(XLBorderStyleValues.DashDot)
				.Border.SetRightBorder(XLBorderStyleValues.DashDot)
				.Border.SetBottomBorder(XLBorderStyleValues.DashDot)
				.Border.SetLeftBorder(XLBorderStyleValues.DashDot);

			workbook.SaveAs(Path);
		}

		public void Draw3()
		{
			var workbook = new XLWorkbook();
			var workSheet = workbook.Worksheets.Add(Sheet);

			//複数のセルに罫線を引く
			var firstCell = workSheet.Cell(2, 2);
			var lastCell = workSheet.Cell(4, 4);

			workSheet.Range(firstCell, lastCell).Style
				.Border.SetOutsideBorder(XLBorderStyleValues.DashDot);

			workSheet.Range(firstCell, lastCell).Style
				.Border.SetInsideBorder(XLBorderStyleValues.Thin);

			workbook.SaveAs(Path);
		}

		public void Draw4()
		{
			var workbook = new XLWorkbook();
			var workSheet = workbook.Worksheets.Add(Sheet);

			//セルに罫線を引く
			workSheet.Cell(2, 2).Style
				.Border.SetDiagonalBorder(XLBorderStyleValues.Thin)
				.Border.SetDiagonalDown(true);

			//セルに罫線を引く
			workSheet.Cell(3, 2).Style
				.Border.SetDiagonalBorder(XLBorderStyleValues.Thick)
				.Border.SetDiagonalUp(true);

			workbook.SaveAs(Path);
		}
	}
}
