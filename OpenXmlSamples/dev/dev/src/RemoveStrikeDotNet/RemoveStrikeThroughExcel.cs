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
				foreach (var cell in cells)
				{
					if (cell.DataType.Value != CellValues.SharedString)
					{
						continue;
					}

					string cellInnerText = string.Empty;
					int itemIndex = int.Parse(cell.InnerText);
					SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(itemIndex);
					if (item.HasChildren)
					{
						//Runクラス(r要素)
						var childrenTypeRun = item.ChildElements.Where(itemChildren => itemChildren is Run);
						if (0 < childrenTypeRun.Count())
						{
							foreach (var childTypeRun in childrenTypeRun)
							{
								//RunPropertyクラス(rPr要素)の有無を確認する。
								var childrenTypeRunProperty = childTypeRun.ChildElements.Where(childTypeRunItem => childTypeRunItem is RunProperties);
								if (0 < childrenTypeRunProperty.Count())
								{
									foreach (var childTypeRunProperty in childrenTypeRunProperty)
									{
										//Strikeクラス(strike要素)の有無の判定
										var childrenTypeStrike = childTypeRunProperty.ChildElements.Where(childTypeRunPropertyItem => childTypeRunPropertyItem is Strike);
										if (0 < childrenTypeStrike.Count())
										{
											//打消し線アリ：スキップする。
											continue;
										}
										else
										{
											//打消し線ナシ：RunPropertyの文字列を、有効な文字列と判断して、保持する。
											cellInnerText += childTypeRun.InnerText;
										}
									}
								}
								else
								{
									/*
									 * RunPropertiesクラス(rPr要素)が無い場合、Runクラスの文字列がセル内の文字列の一部となる。
									 */
									cellInnerText += childTypeRun.InnerText;
									continue;
								}

							}
						}
						else
						{
							/*
							 * Runクラス(r要素)が無い場合、特に編集情報を持たない。
							 * そのため、SharedStringItemの文字列が、そのままセルの文字列となる。
							 */
							cellInnerText = item.InnerText;
						}
					}
					else
					{
						/*
						 * 子要素が無い場合、セルの内部テキストを表示する。
						 */
						cellInnerText = item.InnerText;
					}
					Console.WriteLine($"{cell.CellReference} : {cellInnerText}({item.InnerText})");
				}
			}
			return;
		}
	}
}
