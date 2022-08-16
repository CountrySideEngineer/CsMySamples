﻿using System;
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
		public ExcelTableReader(Stream stream)
		{
			_excelStream = stream;
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
			if (string.IsNullOrEmpty(item))
			{
				throw new ArgumentException("Target item to scane should have any value, not empty.");
			}
			if (null == _excelStream)
			{
				throw new NullReferenceException("Stream data to read has not been set.");
			}
			if ((string.IsNullOrEmpty(SheetName)) || (string.IsNullOrWhiteSpace(SheetName)))
			{
				throw new InvalidDataException("Sheet Name to scan is invalid.");
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
			catch (Exception ex)
			when ((ex is NullReferenceException) || (ex is ArgumentException))
			{
				string message = $"No cell contains \"{item}\" in {SheetName}.";
				throw new ArgumentException(message);
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
			if (string.IsNullOrEmpty(item))
			{
				throw new ArgumentException("Targe item to scan shoul have any value, not empty.");
			}
			if (null == range)
			{
				throw new ArgumentNullException("Range to read has not been set.");
			}
			if (null == _excelStream)
			{
				throw new NullReferenceException("Stream data to read has not been set.");
			}
			if ((string.IsNullOrEmpty(SheetName)) || (string.IsNullOrWhiteSpace(SheetName)))
			{
				throw new InvalidDataException("Sheet Name to scan is invalid.");
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
						(_.Address.RowNumber <= (range.StartRow + range.ColumnCount)) &&
						(range.StartColumn <= _.Address.ColumnNumber) &&
						(_.Address.ColumnNumber <= range.StartColumn + range.ColumnCount))
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
			catch (Exception ex)
			when ((ex is NullReferenceException) || (ex is ArgumentException))
			{
				string message = $"No cell contains \"{item}\" in {SheetName}.";
				throw new ArgumentException(message);
			}
		}

		/// <summary>
		/// Find first cell in a column which conatains an item.
		/// (vertical scan)
		/// </summary>
		/// <param name="item">Item to find.</param>
		/// <param name="range">Range to scan.</param>
		/// <returns>Cell range as Range object</returns>
		public Range FindFirstItemInColumn(string item, Range range)
		{
			if (string.IsNullOrEmpty(item))
			{
				throw new ArgumentException("Targe item to scan shoul have any value, not empty.");
			}
			if (null == range)
			{
				throw new ArgumentNullException("Range to read has not been set.");
			}
			if (null == _excelStream)
			{
				throw new NullReferenceException("Stream data to read has not been set.");
			}
			if ((string.IsNullOrEmpty(SheetName)) || (string.IsNullOrWhiteSpace(SheetName)))
			{
				throw new InvalidDataException("Sheet Name to scan is invalid.");
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
						(_.Address.RowNumber <= (range.StartRow + range.RowCount)) &&
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
			catch (Exception ex)
			when ((ex is NullReferenceException) || (ex is ArgumentException))
			{
				string message = $"No cell contains \"{item}\" in {SheetName}.";
				throw new ArgumentException(message);
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
			if (string.IsNullOrEmpty(item))
			{
				throw new ArgumentException("Targe item to scan shoul have any value, not empty.");
			}
			if (null == range)
			{
				throw new ArgumentNullException("Range to read has not been set.");
			}
			if (null == _excelStream)
			{
				throw new NullReferenceException("Stream data to read has not been set.");
			}
			if ((string.IsNullOrEmpty(SheetName)) || (string.IsNullOrWhiteSpace(SheetName)))
			{
				throw new InvalidDataException("Sheet Name to scan is invalid.");
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
						(_.Address.ColumnNumber <= (range.StartColumn + range.ColumnCount)))
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
			catch (Exception ex)
			when ((ex is NullReferenceException) || (ex is ArgumentException))
			{
				string message = $"No cell contains \"{item}\" in {SheetName}.";
				throw new ArgumentException(message);
			}
		}

		/// <summary>
		/// Get range of cell which contains the string specified by argument "item".
		/// </summary>
		/// <param name="item">String a cell should contain.</param>
		/// <returns>Collection of cells which contain "item".</returns>
		public IEnumerable<Range> FindItem(string item)
		{
			if ((string.IsNullOrEmpty(item)) || (string.IsNullOrWhiteSpace(item)))
			{
				string message = "Target string must not be empty.";
				throw new ArgumentException(message);
			}

			var workBook = new XLWorkbook(_excelStream);
			var workSheet = workBook.Worksheet(SheetName);
			var itemCells = workSheet.CellsUsed().Where(_ => 0 == string.Compare(_.GetString(), item));
			if (0 == itemCells.Count())
			{
				throw new ArgumentException($"No cell contains \"{item}\" in {SheetName}.");
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

		/// <summary>
		/// Get range about column.
		/// </summary>
		/// <param name="range">Reference to Range object to set result.</param>
		public void GetColumnRange(ref Range range)
		{
			var workBook = new XLWorkbook(_excelStream);
			var workSheet = workBook.Worksheet(SheetName);

			var firstUsedCell = workSheet.FirstColumnUsed();
			range.StartColumn = firstUsedCell.ColumnNumber();

			var lastUsedCell = workSheet.LastColumnUsed();
			range.ColumnCount = lastUsedCell.ColumnNumber() - firstUsedCell.ColumnNumber() + 1;
		}

		/// <summary>
		/// Get merged cell range.
		/// </summary>
		/// <param name="range">Range of merged cell.</param>
		public void GetMergedCellRange(ref Range range)
		{
			var workBook = new XLWorkbook(_excelStream);
			var workSheet = workBook.Worksheet(SheetName);

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

		/// <summary>
		/// Get row range.
		/// </summary>
		/// <param name="range">Range to set.</param>
		public void GetRowRange(ref Range range)
		{
			var workBook = new XLWorkbook(_excelStream);
			var workSheet = workBook.Worksheet(SheetName);

			var firstCell = workSheet.FirstRowUsed();
			range.StartRow = firstCell.RowNumber();

			var lastCell = workSheet.LastRowUsed();
			range.RowCount = lastCell.RowNumber() - firstCell.RowNumber() + 1;
		}

		public void GetTableRange(ref Range range)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<string> ReadColumn(Range range)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<string> ReadRow(Range range)
		{
			throw new NotImplementedException();
		}
	}
}
