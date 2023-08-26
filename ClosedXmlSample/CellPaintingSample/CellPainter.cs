using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CellPaintingSample
{
	internal class CellPainter
	{
		public string Path { get; set; }

		public string Sheet { get; set; }

		public CellPainter()
		{
			Path = string.Empty;
			Sheet = string.Empty;
		}

		public CellPainter(string path, string sheet = "")
		{
			Path = path;
			Sheet = sheet;
		}

		public void Paint1()
		{
			using (var workbook = new XLWorkbook())
			{
				var workSheet = workbook.Worksheets.Add(Sheet);

				workSheet.Cell(2, 2).Style
					.Fill.SetBackgroundColor(XLColor.ArylideYellow);

				workbook.SaveAs(Path);
			}
		}

		public void Paint2()
		{
			using (var workbook = new XLWorkbook())
			{
				var workSheet = workbook.Worksheets.Add(Sheet);

				var start = workSheet.Cell(2, 2);
				var end = workSheet.Cell(3, 3);
				workSheet.Range(start, end).
					Style.Fill.SetBackgroundColor(XLColor.GreenPigment);

				workbook.SaveAs(Path);
			}
		}

		public void Paint3()
		{
			using (var workbook = new XLWorkbook())
			{
				var workSheet = workbook.Worksheets.Add(Sheet);

				workSheet.Cell(2, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.DarkDown);
				workSheet.Cell(2, 2).Value = "XLFillPatternValues.DarkDown";

				workSheet.Cell(2, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.DarkGray);
				workSheet.Cell(2, 4).Value = "XLFillPatternValues.DarkGray";

				workSheet.Cell(4, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.DarkGrid);
				workSheet.Cell(4, 2).Value = "XLFillPatternValues.DarkGrid";

				workSheet.Cell(4, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.DarkHorizontal);
				workSheet.Cell(4, 4).Value = "XLFillPatternValues.DarkHorizontal";

				workSheet.Cell(6, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.DarkTrellis);
				workSheet.Cell(6, 2).Value = "XLFillPatternValues.DarkTrellis";

				workSheet.Cell(6, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.DarkUp);
				workSheet.Cell(6, 4).Value = "XLFillPatternValues.DarkUp";

				workSheet.Cell(8, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.DarkVertical);
				workSheet.Cell(8, 2).Value = "XLFillPatternValues.DarkVertical";

				workSheet.Cell(8, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.Gray0625);
				workSheet.Cell(8, 4).Value = "XLFillPatternValues.Gray0625";

				workSheet.Cell(10, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.Gray125);
				workSheet.Cell(10, 2).Value = "XLFillPatternValues.Gray125";

				workSheet.Cell(10, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.LightDown);
				workSheet.Cell(10, 4).Value = "XLFillPatternValues.LightDown";

				workSheet.Cell(12, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.Gray125);
				workSheet.Cell(12, 2).Value = "XLFillPatternValues.Gray125";

				workSheet.Cell(12, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.LightDown);
				workSheet.Cell(12, 4).Value = "XLFillPatternValues.LightDown";

				workSheet.Cell(14, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.LightGray);
				workSheet.Cell(14, 2).Value = "XLFillPatternValues.LightGray";

				workSheet.Cell(14, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.LightGrid);
				workSheet.Cell(14, 4).Value = "XLFillPatternValues.LightGrid";

				workSheet.Cell(16, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.LightHorizontal);
				workSheet.Cell(16, 2).Value = "XLFillPatternValues.LightHorizontal";

				workSheet.Cell(16, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.LightTrellis);
				workSheet.Cell(16, 4).Value = "XLFillPatternValues.LightTrellis";

				workSheet.Cell(18, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.LightUp);
				workSheet.Cell(18, 2).Value = "XLFillPatternValues.LightUp";

				workSheet.Cell(18, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.LightVertical);
				workSheet.Cell(18, 4).Value = "XLFillPatternValues.LightVertical";

				workSheet.Cell(20, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.MediumGray);
				workSheet.Cell(20, 2).Value = "XLFillPatternValues.MediumGray";

				workSheet.Cell(20, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.None);
				workSheet.Cell(20, 4).Value = "XLFillPatternValues.None";

				workSheet.Cell(22, 2).Style
					.Fill.SetBackgroundColor(XLColor.LightBlue)
					.Fill.SetPatternType(XLFillPatternValues.Solid);
				workSheet.Cell(22, 2).Value = "XLFillPatternValues.Solid";

				workbook.SaveAs(Path);
			}

		}

		public void Paint4()
		{
			using (var workbook = new XLWorkbook())
			{
				var workSheet = workbook.Worksheets.Add(Sheet);

				workSheet.Cell(2, 2).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternType(XLFillPatternValues.DarkDown)
					.Fill.SetPatternColor(XLColor.Red);
				workSheet.Cell(2, 2).Value = "XLFillPatternValues.DarkDown";

				workSheet.Cell(2, 4).Style
					.Fill.SetBackgroundColor(XLColor.Transparent)
					.Fill.SetPatternColor(XLColor.Red)
					.Fill.SetPatternType(XLFillPatternValues.LightDown);	//メソッドの実行順によっては、色が設定されない。
				workSheet.Cell(2, 4).Value = "XLFillPatternValues.LightDown";

				workbook.SaveAs(Path);
			}
		}
	}
}
