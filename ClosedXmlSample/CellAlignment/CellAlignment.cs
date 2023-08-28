using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellAlignment
{
	internal class CellAlignment
	{
		public string Path { get; set; }

		public string Sheet { get; set; }

		public CellAlignment()
		{
			Path = string.Empty;
			Sheet = string.Empty;
		}

		public CellAlignment(string path, string sheet = "")
		{
			Path = path;
			Sheet = sheet;
		}

		public void Alignment1()
		{
			using (var workbook = new XLWorkbook())
			{
				var workSheet = workbook.Worksheets.Add(Sheet);

				workSheet.Cell(2, 2).Style
					.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
					.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
				workSheet.Cell(2, 2).Value = "XLAlignmentHorizontalValues.Justify, XLAlignmentVerticalValues.Bottom";

				workSheet.Cell(4, 2).Style
					.Alignment.SetHorizontal(XLAlignmentHorizontalValues.CenterContinuous)
					.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
				workSheet.Cell(4, 2).Value = "XLAlignmentHorizontalValues.CenterContinuous, XLAlignmentVerticalValues.Center";

				workSheet.Cell(6, 2).Style
					.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Distributed)
					.Alignment.SetVertical(XLAlignmentVerticalValues.Distributed);
				workSheet.Cell(6, 2).Value = "XLAlignmentHorizontalValues.Distributed, XLAlignmentVerticalValues.Distributed";

				workSheet.Cell(8, 2).Style
					.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Fill)
					.Alignment.SetVertical(XLAlignmentVerticalValues.Justify);
				workSheet.Cell(8, 2).Value = "XLAlignmentHorizontalValues.Fill, XLAlignmentVerticalValues.Justify";

				workSheet.Cell(10, 2).Style
					.Alignment.SetHorizontal(XLAlignmentHorizontalValues.General)
					.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
				workSheet.Cell(10, 2).Value = "XLAlignmentHorizontalValues.General, XLAlignmentVerticalValues.Top";

				workSheet.Cell(12, 2).Style
					.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Justify)
					.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
				workSheet.Cell(12, 2).Value = "XLAlignmentHorizontalValues.Justify, XLAlignmentVerticalValues.Top";

				workSheet.Cell(14, 2).Style
					.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left)
					.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
				workSheet.Cell(14, 2).Value = "XLAlignmentHorizontalValues.Left, XLAlignmentVerticalValues.Top";

				workSheet.Cell(16, 2).Style
					.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
					.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
				workSheet.Cell(16, 2).Value = "XLAlignmentHorizontalValues.Right, XLAlignmentVerticalValues.Top";

				workbook.SaveAs(Path);
			}
		}
	}
}
