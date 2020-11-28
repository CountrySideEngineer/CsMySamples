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
				var sheet = workbookPart.Workbook.Descendants<Sheet>().Where(sheetItem => sheetItem.Name == "image").FirstOrDefault();
				if (null == sheet)
				{
					Console.WriteLine("Sheet can not be found in the file.");

					return;
				}
				var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
				var styleSheet = workbookPart.WorkbookStylesPart.Stylesheet;
				var cells = worksheetPart.Worksheet.Descendants<Cell>();
				var sharedStringCells = cells.Where(cellItem => (null != cellItem.DataType) && (cellItem.DataType.Value == CellValues.SharedString));
				foreach (var sharedStringCell in sharedStringCells)
				{
					string cellInnerText = string.Empty;
					int itemIndex = int.Parse(sharedStringCell.InnerText);
					SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(itemIndex);
					try
					{
						/*
						 * The font data applied to each cells in a excel file is stored in cellXfs element in styles.xml file.
						 * The element, cellXfs, can be get from "CellFormats" property in StyleSheet.
						 * And the font data each cells contain can be specified from CellFormats property by StyleIndex
						 * variable.
						 */
						var cellFormat = (CellFormat)styleSheet.CellFormats.ElementAt(int.Parse(sharedStringCell.StyleIndex));
						/*
						 * The font information actually applied to the cell is stored in fonts element in styles.xml file.
						 * The data can be get by CellFormat.FontId.
						 */
						var cellFontId = cellFormat.FontId;
						var cellFont = styleSheet.Fonts.ElementAt(int.Parse(cellFontId));
						var cellFontStrikeElement = cellFont.ChildElements.Where(cellFontItem => cellFontItem is Strike);
						if (0 < cellFontStrikeElement.Count())
						{
							Console.WriteLine($"セルに取り消し線が設定されています。({sharedStringCell.CellReference})");

							continue;
						}

						var phoneticProperty = item.Elements<PhoneticProperties>().FirstOrDefault();
						var fontId = int.Parse(phoneticProperty.FontId);
						var fonts = styleSheet.Fonts.Elements();
						var fontItem = fonts.ElementAt((int)fontId);
						var cellStrike = fontItem.Elements<Strike>();
						if (0 < cellStrike.Count())
						{
							Console.WriteLine(item.InnerText);

							continue;
						}
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
					Console.WriteLine($"{sharedStringCell.CellReference} : {cellInnerText}({item.InnerText})({sharedStringCell.StyleIndex})");
				}
			}
			return;
		}
	}
}
