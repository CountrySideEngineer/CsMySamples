using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableReader.Interface;
using TableReader.TableData;
using System.IO;
using ClosedXML.Excel;

namespace TableReader.Excel
{
	public class ExcelTableReader : ITableReader
	{
		/// <summary>
		/// Excel stream data a table to read is set.
		/// </summary>
		protected Stream _excelStream;

		/// <summary>
		/// Sheet name to read.
		/// </summary>
		public string SheetName { get; set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <remarks>Unaccesstable!</remarks>
		protected ExcelTableReader()
		{
			_excelStream = null;
		}

		/// <summary>
		/// Constructor with argument about excel file stream.
		/// </summary>
		/// <param name="stream">Stream data to excel file to read.</param>
		/// <param name="sheetName">Sheet name to read.</param>
		public ExcelTableReader(Stream stream, string sheetName = "")
		{
			_excelStream = stream;
			SheetName = sheetName;
		}

		/// <summary>
		/// Get table content.
		/// </summary>
		/// <param name="name">Table name</param>
		/// <returns>Table content as collection of row</returns>
		public Content GetTable(string name)
		{
			var offset = new Range()
			{
				RowCount = 1,
				ColumnCount = 1
			};
			return GetTable(name, offset);
		}

		/// <summary>
		/// Get table content.
		/// </summary>
		/// <param name="name">Table name.</param>
		/// <param name="offset">Offset to start reading table.</param>
		/// <returns>Table content as collection of row.</returns>
		public Content GetTable(string name, Range offset)
		{
			CheckParameter();

			Range tableRange = GetTableRange(name, offset);
			IEnumerable<Range> rowRangeCollection = RangeToRowCollection(tableRange);
			var tableContent = new List<IEnumerable<string>>();
			foreach (var rowRangeItem in rowRangeCollection)
			{
				var rowContent = ReadRow(rowRangeItem);
				tableContent.Add(rowContent);
			}
			var content = new ExcelTableContent()
			{
				TableContent = tableContent
			};
			return content;
		}

		/// <summary>
		/// Convert Range object to collection Range object in vertical direction.
		/// </summary>
		/// <param name="range">Range object to be converted.</param>
		/// <returns>Collection of Range object covnerted.</returns>
		protected IEnumerable<Range> RangeToRowCollection(Range range)
		{
			var rangeCollection = new List<Range>();
			for (int index = 0; index < range.RowCount; index++)
			{
				var rowRange = new Range(range);
				rowRange.StartRow += index;
				rowRange.RowCount = 1;
				rangeCollection.Add(rowRange);
			}
			return rangeCollection;
		}

		/// <summary>
		/// Convert Range object to collection of Range object in horizontal collection.
		/// </summary>
		/// <param name="range">Range object to be converted.</param>
		/// <returns>Collection of Range object converted.</returns>
		protected IEnumerable<Range> RangeToColCollection(Range range)
		{
			var rangeCollection = new List<Range>();
			for (int index = 0; index < range.ColumnCount; index++)
			{
				var rowRange = new Range(range);
				rowRange.StartColumn += index;
				rowRange.ColumnCount = 1;
				rangeCollection.Add(rowRange);
			}
			return rangeCollection;
		}

		/// <summary>
		/// Check parameter.
		/// </summary>
		/// <exception cref="NullReferenceException"></exception>
		/// <exception cref="InvalidDataException"></exception>
		protected void CheckParameter()
		{
			if (null == _excelStream)
			{
				throw new NullReferenceException("Stream data to read has not been set.");
			}
			if ((string.IsNullOrEmpty(SheetName)) || (string.IsNullOrWhiteSpace(SheetName)))
			{
				throw new InvalidDataException("Sheet Name to scan is invalid.");
			}
		}

		/// <summary>
		/// Get the address of the first cell containing the "item" value.
		/// </summary>
		/// <param name="item">The value to scan.</param>
		/// <returns>Address of fist cell as Range object.</returns>
		/// <exception cref="ArgumentException">The item has not been set.</exception>
		/// <exception cref="NullReferenceException">Stream to read has not been set.</exception>
		/// <exception cref="InvalidDataException">Sheet name to scan is invalid.</exception>
		public Range FindFirstItem(string item)
		{
			CheckParameter();

			if (string.IsNullOrEmpty(item))
			{
				throw new ArgumentException("The string to be searched must have value set.");
			}
			try
			{
				var workBook = new XLWorkbook(_excelStream);
				var workSheet = workBook.Worksheet(SheetName);
				var usedCells = workSheet.CellsUsed();
				var itemCell = usedCells
						.Where(_ => 0 == string.Compare(item, _.GetString()))
						.FirstOrDefault();
				var range = new Range()
				{
					StartRow = itemCell.Address.RowNumber,
					StartColumn = itemCell.Address.ColumnNumber,
					RowCount = 1,
					ColumnCount = 1,
				};
				return range;
			}
			catch (NullReferenceException)
			{
				string message = $"No cell contains \"{item}\" in {SheetName}.";
				throw new ArgumentException(message);
			}
			catch (ArgumentException ex)
			{
				if (string.IsNullOrEmpty(ex.Message))
				{
					string message = $"No cell contains \"{item}\" in {SheetName}.";
					throw new ArgumentException(message);
				}
				else
				{
					throw;
				}
			}
		}

		/// <summary>
		/// Get the address of the first cell in the range specified by "range" and containing the "item" value.
		/// </summary>
		/// <param name="item">The value to scan.</param>
		/// <param name="range">Range to scan.</param>
		/// <returns>Address of first cell as Range object.</returns>
		/// <exception cref="ArgumentException">The item has not been set.</exception>
		/// <exception cref="ArgumentNullException">The range argument is invalid, null.</exception>
		/// <exception cref="NullReferenceException">Stream to read has not been set.</exception>
		/// <exception cref="InvalidDataException">Sheet name to scan is invalid.</exception>
		public Range FindFirstItem(string item, Range range)
		{
			CheckParameter();

			if (string.IsNullOrEmpty(item))
			{
				throw new ArgumentException("Targe item to scan shoul have any value, not empty.");
			}
			if (null == range)
			{
				throw new ArgumentNullException("Range to read has not been set.");
			}
			try
			{
				var workBook = new XLWorkbook(_excelStream);
				var workSheet = workBook.Worksheet(SheetName);
				var firstCell = workSheet
					.CellsUsed()
					.Where(_ =>
						(0 == string.Compare(_.GetString(), item)) &&
						(range.StartRow <= _.Address.RowNumber) &&
						(_.Address.RowNumber <= (range.StartRow + range.RowCount - 1)) &&
						(range.StartColumn <= _.Address.ColumnNumber) &&
						(_.Address.ColumnNumber <= range.StartColumn + range.ColumnCount - 1))
					.FirstOrDefault();
				Range itemRange = new Range()
				{
					StartRow = firstCell.Address.RowNumber,
					StartColumn = firstCell.Address.ColumnNumber,
					RowCount = 1,
					ColumnCount = 1,
				};
				return itemRange;
			}
			catch (NullReferenceException)
			{
				string message = $"No cell contains \"{item}\" in {SheetName}.";
				throw new ArgumentException(message);
			}
			catch (ArgumentException ex)
			{
				if (string.IsNullOrEmpty(ex.Message))
				{
					string message = $"No cell contains \"{item}\" in {SheetName}.";
					throw new ArgumentException(message);
				}
				else
				{
					throw;
				}
			}
		}

		/// <summary>
		/// Find first cell in a column which conatains an item.
		/// (vertical scan)
		/// </summary>
		/// <param name="item">Item to find.</param>
		/// <param name="range">Range to scan.</param>
		/// <returns>Cell range as Range object</returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		public Range FindFirstItemInColumn(string item, Range range)
		{
			CheckParameter();
			if (string.IsNullOrEmpty(item))
			{
				throw new ArgumentException("Targe item to scan shoul have any value, not empty.");
			}
			if (null == range)
			{
				throw new ArgumentNullException($"{nameof(range)}", "Range to read has not been set.");
			}
			try
			{
				var workBook = new XLWorkbook(_excelStream);
				var workSheet = workBook.Worksheet(SheetName);
				var itemCell = workSheet
					.CellsUsed()
					.Where(_ =>
						(0 == string.Compare(item, _.GetString())) &&
						(range.StartRow <= _.Address.RowNumber) &&
						(_.Address.RowNumber <= (range.StartRow + range.RowCount - 1)) &&
						(_.Address.ColumnNumber == range.StartColumn))
					.FirstOrDefault();
				Range itemRange = new Range()
				{
					StartRow = itemCell.Address.RowNumber,
					StartColumn = itemCell.Address.ColumnNumber,
					RowCount = 1,
					ColumnCount = 1,
				};
				return itemRange;
			}
			catch (NullReferenceException)
			{
				string message = $"No cell contains \"{item}\" in {SheetName}.";
				throw new ArgumentException(message);
			}
			catch (ArgumentException ex)
			{
				if (string.IsNullOrEmpty(ex.Message))
				{
					string message = $"No cell contains \"{item}\" in {SheetName}.";
					throw new ArgumentException(message);
				}
				else
				{
					throw;
				}
			}
		}

		/// <summary>
		/// Find first cell in a row which conatains an item.
		/// (Horizontal scan)
		/// </summary>
		/// <param name="item">Item to find.</param>
		/// <param name="range">Range to scan.</param>
		/// <returns>Cell range as Range object</returns>
		public Range FindFirstItemInRow(string item, Range range)
		{
			CheckParameter();

			if (string.IsNullOrEmpty(item))
			{
				throw new ArgumentException("Targe item to scan shoul have any value, not empty.");
			}
			if (null == range)
			{
				throw new ArgumentNullException($"{nameof(range)}", "Range to read has not been set.");
			}
			try
			{
				var workBook = new XLWorkbook(_excelStream);
				var workSheet = workBook.Worksheet(SheetName);
				var itemCell = workSheet
					.CellsUsed()
					.Where(_ =>
						(0 == string.Compare(item, _.GetString())) &&
						(range.StartRow == _.Address.RowNumber) &&
						(range.StartColumn <= _.Address.ColumnNumber) &&
						(_.Address.ColumnNumber <= (range.StartColumn + range.ColumnCount - 1)))
					.FirstOrDefault();
				Range itemRange = new Range()
				{
					StartRow = itemCell.Address.RowNumber,
					StartColumn = itemCell.Address.ColumnNumber,
					RowCount = 1,
					ColumnCount = 1,
				};
				return itemRange;
			}
			catch (NullReferenceException)
			{
				string message = $"No cell contains \"{item}\" in {SheetName}.";
				throw new ArgumentException(message);
			}
			catch (ArgumentException ex)
			{
				if (string.IsNullOrEmpty(ex.Message))
				{
					string message = $"No cell contains \"{item}\" in {SheetName}.";
					throw new ArgumentException(message);
				}
				else
				{
					throw;
				}
			}
		}

		/// <summary>
		/// Get range of cell which contains the string specified by argument "item".
		/// </summary>
		/// <param name="item">String a cell should contain.</param>
		/// <returns>Collection of cells which contain "item".</returns>
		public IEnumerable<Range> FindItem(string item)
		{
			CheckParameter();

			if ((string.IsNullOrEmpty(item)) || (string.IsNullOrWhiteSpace(item)))
			{
				string message = "Target string must not be empty.";
				throw new ArgumentException(message);
			}

			try
			{
				var workBook = new XLWorkbook(_excelStream);
				var workSheet = workBook.Worksheet(SheetName);
				var itemCells = workSheet.CellsUsed().Where(_ => 0 == string.Compare(_.GetString(), item));
				if (0 == itemCells.Count())
				{
					string message = $"No cell contains \"{item}\" in {SheetName}.";
					throw new ArgumentException(message);
				}
				var ranges = new List<Range>();
				foreach (var itemCell in itemCells)
				{
					Range range = new Range()
					{
						StartRow = itemCell.Address.RowNumber,
						StartColumn = itemCell.Address.ColumnNumber,
						RowCount = 1,
						ColumnCount = 1,
					};
					ranges.Add(range);
				}
				return ranges;
			}
			catch (NullReferenceException)
			{
				string message = $"No cell contains \"{item}\" in {SheetName}.";
				throw new ArgumentException(message);
			}
			catch (ArgumentException ex)
			{
				if (string.IsNullOrEmpty(ex.Message))
				{
					string message = $"No cell contains \"{item}\" in {SheetName}.";
					throw new ArgumentException(message);
				}
				else
				{
					throw;
				}
			}
		}

		/// <summary>
		/// Get column count (Width of table).
		/// </summary>
		/// <param name="range">Reference to Range object to set result.</param>
		/// <exception cref="ArgumentNullException"></exception>
		public void GetColumnRange(ref Range range)
		{
			CheckParameter();
			try
			{
				var workBook = new XLWorkbook(_excelStream);
				var workSheet = workBook.Worksheet(SheetName);

				var firstUsedCell = workSheet.FirstColumnUsed();
				range.StartColumn = firstUsedCell.ColumnNumber();

				var lastUsedCell = workSheet.LastColumnUsed();
				range.ColumnCount = lastUsedCell.ColumnNumber() - firstUsedCell.ColumnNumber() + 1;
			}
			catch (NullReferenceException)
			{
				string message = "Argument Range is must not be null.";
				throw new ArgumentNullException(message);
			}
		}

		/// <summary>
		/// Get merged cell range.
		/// </summary>
		/// <param name="range">Range of merged cell.</param>
		/// <exception cref="ArgumentNullException"></exception>
		public void GetMergedCellRange(ref Range range)
		{
			CheckParameter();

			var workBook = new XLWorkbook(_excelStream);
			var workSheet = workBook.Worksheet(SheetName);

			try
			{
				if (workSheet.Cell(range.StartRow, range.StartColumn).IsMerged())
				{
					var mergedRange = workSheet.Cell(range.StartRow, range.StartColumn).MergedRange();
					var firstCell = mergedRange.FirstCell();
					var lastCell = mergedRange.LastCell();
					range.StartRow = firstCell.Address.RowNumber;
					range.StartColumn = firstCell.Address.ColumnNumber;
					range.RowCount = lastCell.Address.RowNumber - firstCell.Address.RowNumber + 1;
					range.ColumnCount = lastCell.Address.ColumnNumber - firstCell.Address.ColumnNumber + 1;
				}
				else
				{
					range.RowCount = 1;
					range.ColumnCount = 1;
				}
			}
			catch (NullReferenceException)
			{
				string message = "Argument Range is must not be null.";
				throw new ArgumentNullException(message);
			}
		}

		/// <summary>
		/// Get row range.
		/// </summary>
		/// <param name="range">Range to set.</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="InvalidDataException"></exception>
		public void GetRowRange(ref Range range)
		{
			CheckParameter();

			try
			{
				var workBook = new XLWorkbook(_excelStream);
				var workSheet = workBook.Worksheet(SheetName);

				var firstCell = workSheet.FirstRowUsed();
				range.StartRow = firstCell.RowNumber();

				var lastCell = workSheet.LastRowUsed();
				range.RowCount = lastCell.RowNumber() - firstCell.RowNumber() + 1;
			}
			catch (NullReferenceException ex)
			{
				string message = $"No used cell has been found in {SheetName}.";
				throw new InvalidDataException(message, ex);
			}
		}

		/// <summary>
		/// Get table range.
		/// </summary>
		/// <param name="range">Range object to set result.</param>
		/// <exception cref="InvalidDataException"></exception>
		/// <exception cref="NullReferenceException"></exception>
		public void GetTableRange(ref Range range)
		{
			CheckParameter();

			try
			{
				Range rowRange = new Range();
				GetRowRange(ref rowRange);

				Range columnRange = new Range();
				GetColumnRange(ref columnRange);

				range.StartRow = rowRange.StartRow;
				range.RowCount = rowRange.RowCount;
				range.StartColumn = columnRange.StartColumn;
				range.ColumnCount = columnRange.ColumnCount;
			}
			catch (ArgumentNullException)
			{
				throw;
			}
			catch (InvalidDataException ex)
			{
				if (ex.InnerException is NullReferenceException)
				{
					range.StartRow = 0;
					range.StartColumn = 0;
					range.RowCount = 0;
					range.ColumnCount = 0;
				}
				else
				{
					throw;
				}
			}
		}

		/// <summary>
		/// Read column and get value in cells.
		/// (Read vertical).
		/// </summary>
		/// <param name="range">Range to read.</param>
		/// <returns>Collection of cell value as string.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public IEnumerable<string> ReadColumn(Range range)
		{
			CheckParameter();

			try
			{
				var workBook = new XLWorkbook(_excelStream);
				var workSheet = workBook.Worksheet(SheetName);
				var rowRange = new Range(range);
				GetRowRange(ref rowRange);
				rowRange.StartRow = range.StartRow;	//The StartRow in rowRange is overwritten in GetRowRange(). reset the change.

				List<string> cellItems = new List<string>();
				int tailIndex = GetLastRowInColumn(workSheet, rowRange);
				for (int rowIndex = rowRange.StartRow; rowIndex <= tailIndex; rowIndex++)
				{
					var cell = workSheet.Cell(rowIndex, range.StartColumn);
					string cellItem = cell.GetString();
					cellItems.Add(cellItem);
				}
				return cellItems;
			}
			catch (NullReferenceException)
			{
				string message = "Argument Range is must not be null.";
				throw new ArgumentNullException(message);
			}
		}

		/// <summary>
		/// Read row and get value in cells.
		/// (Read horizontal)
		/// </summary>
		/// <param name="range">Range to read.</param>
		/// <returns>Collection of cell value as string.</returns>
		public IEnumerable<string> ReadRow(Range range)
		{
			var workBook = new XLWorkbook(_excelStream);
			var workSheet = workBook.Worksheet(SheetName);
			var columnRange = new Range(range);
			GetColumnRange(ref columnRange);
			columnRange.StartColumn = range.StartColumn;

			List<string> cellItems = new List<string>();
			int tailIndex = GetLastColumnInRow(workSheet, columnRange);
			for (int columnIndex = columnRange.StartColumn; columnIndex <= tailIndex; columnIndex++)
			{
				var cell = workSheet.Cell(range.StartRow, columnIndex);
				string cellItem = cell.GetString();
				cellItems.Add(cellItem);
			}
			return cellItems;
		}

		/// <summary>
		/// Get the index of the last row of the specified column by argument.
		/// </summary>
		/// <param name="workSheet">Worksheet object.</param>
		/// <param name="range">Range to scan.</param>
		/// <returns>The index of the last row.</returns>
		protected int GetLastRowInColumn(IXLWorksheet workSheet, Range range)
		{
			int rowIndex = 0;
			var rowRange = new Range(range);
			for (rowIndex = rowRange.StartRow + range.RowCount - 1; rowRange.StartRow <= rowIndex; rowIndex--)
			{
				var cell = workSheet.Cell(rowIndex, rowRange.StartColumn);
				string cellValue = cell.GetString();
				if ((!string.IsNullOrEmpty(cellValue)) && (!string.IsNullOrWhiteSpace(cellValue)))
				{
					break;
				}
			}
			return rowIndex;
		}

		/// <summary>
		/// Get the index of the last column of the specified row by argument.
		/// </summary>
		/// <param name="workSheet">Worksheet object.</param>
		/// <param name="range">Range to scan.</param>
		/// <returns>The index of the last column.</returns>
		protected int GetLastColumnInRow(IXLWorksheet workSheet, Range range)
		{
			int columnIndex = 0;
			var columnRange = new Range(range);
			for (columnIndex = columnRange.StartColumn + columnRange.ColumnCount - 1; columnRange.StartColumn <= columnIndex; columnIndex--)
			{
				var cell = workSheet.Cell(columnRange.StartRow, columnIndex);
				string cellValue = cell.GetString();
				if ((!string.IsNullOrEmpty(cellValue)) && (!string.IsNullOrWhiteSpace(cellValue)))
				{
					break;
				}
			}
			return columnIndex;
		}

		/// <summary>
		/// Get range of table.
		/// </summary>
		/// <param name="name">Table name.</param>
		/// <param name="offset">Table offset from </param>
		/// <returns>Table range, row and column number at the top of table and the number of the row and column.</returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="InvalidDataException"></exception>
		/// <exception cref="NullReferenceException"></exception>
		protected Range GetTableRange(string name, Range offset)
		{
			CheckParameter();

			Range nameCellRange = FindFirstItem(name);
			var sheetRange = new Range();
			GetTableRange(ref sheetRange);

			int startRow = nameCellRange.StartRow + offset.RowCount;
			int startCol = nameCellRange.StartColumn + offset.ColumnCount;
			int lastRow = sheetRange.StartRow + sheetRange.RowCount - 1;
			int lastColumn = sheetRange.StartColumn + sheetRange.ColumnCount - 1;
			int rowCount = lastRow - startRow + 1;
			int colCount = lastColumn - startCol + 1;

			if ((startRow < 1) || (startCol < 1) ||
				(lastRow < 1) || (lastColumn < 1) ||
				(lastRow < startRow) || (lastColumn < startCol) ||
				(rowCount < 1) || (colCount < 1))
			{
				throw new ArgumentOutOfRangeException();
			}

			var tableRange = new Range()
			{
				StartRow = startRow,
				StartColumn = startCol,
				RowCount = rowCount,
				ColumnCount = colCount
			};
			return tableRange;
		}
	}
}
