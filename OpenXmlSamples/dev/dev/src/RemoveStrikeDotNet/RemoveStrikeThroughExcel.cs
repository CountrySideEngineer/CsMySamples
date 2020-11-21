using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveStrikeDotNet
{
	class RemoveStrikeThroughExcel
	{
		static void Main(string[] args)
		{
			var excelFileName = @"./../image.xlsx";

			using (var document = SpreadsheetDocument.Open(excelFileName, false))
			{
				var workbookPart = document.WorkbookPart;
				var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
				var sheet = workbookPart.Workbook.Descendants<Sheet>().Where(sheetItem => sheetItem.Name == "image").FirstOrDefault();
				if (null == sheet)
				{
					Console.WriteLine("Sheet can not be found in the file.");

					return;
				}
				var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
				var cells = worksheetPart.Worksheet.Descendants<Cell>();
				var sharedStringCells = cells.Where(cellItem => (null != cellItem.DataType) && (cellItem.DataType.Value == CellValues.SharedString));
				foreach (var sharedStringCell in sharedStringCells)
				{
					string cellInnerText = string.Empty;
					int itemIndex = int.Parse(sharedStringCell.InnerText);
					SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(itemIndex);
					try
					{
						var runElements = item.Elements<Run>();
						if (0 < runElements.Count())
						{
							/*
							 * Check the format informations have strikethrough element
							 * if one or more r element can be found.
							 */
							foreach (var runElement in runElements)
							{
								var runPropertyElements = runElement.RunProperties;
								var strikeElements = runPropertyElements.Elements<Strike>();
								if (0 < strikeElements.Count())
								{
									continue;
								}
								else
								{
									cellInnerText += runElement.InnerText;
								}
							}
						}
						else
						{
							cellInnerText += item.InnerText;
						}
					}
					catch (Exception)
					{
						cellInnerText += item.InnerText;
					}
					Console.WriteLine($"{sharedStringCell.CellReference} : {cellInnerText}({item.InnerText})");
				}
			}
			return;
		}
	}
}
