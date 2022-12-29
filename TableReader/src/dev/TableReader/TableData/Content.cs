using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReader.TableData
{
	public class Content
	{
		/// <summary>
		/// Talbe conent field.
		/// This is collection of row.
		/// </summary>
		protected IEnumerable<IEnumerable<string>> _tableContent;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Content()
		{
			_tableContent = new List<List<string>>();
		}

		/// <summary>
		/// Returns the number of row in the content.
		/// </summary>
		/// <returns>The number of row.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="OverflowException"></exception>
		public int RowCount()
		{
			try
			{
				int rowCount = _tableContent.Count();

				return rowCount;
			}
			catch (Exception ex)
			when ((ex is NullReferenceException) || (ex is ArgumentNullException))
			{
				throw new NullReferenceException();
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Get content of cell specified by row and col
		/// </summary>
		/// <param name="row">Table row index, 0 base.</param>
		/// <param name="col">Table col index, 0 base.</param>
		/// <returns>Content in the cell.</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public string GetContent(int row, int col)
		{
			try
			{
				IEnumerable<string> rowItems = _tableContent.ElementAt(row);
				string item = rowItems.ElementAt(col);

				return item;
			}
			catch (ArgumentOutOfRangeException) { throw; }
		}

		/// <summary>
		/// Get contents in row.
		/// </summary>
		/// <param name="row">Table row index to get, 0 base.</param>
		/// <returns>Collection of item in row.</returns>
		public IEnumerable<string> GetContentsInRow(int row)
		{
			try
			{
				IEnumerable<string> contentsInRow = _tableContent.ElementAt(row);
				return contentsInRow;
			}
			catch (ArgumentOutOfRangeException) { throw; }
		}

		/// <summary>
		/// Get contents in col
		/// </summary>
		/// <param name="col">Table column index to get, 0 base.</param>
		/// <returns>Collection of item in column.</returns>
		public IEnumerable<string> GetContentsInCol(int col)
		{
			try
			{
				var colItems = new List<string>();
				foreach (var rowContents in _tableContent)
				{
					string item = rowContents.ElementAt(col);
					colItems.Add(item);
				}
				return colItems;
			}
			catch (ArgumentOutOfRangeException) { throw; }
		}

		/// <summary>
		/// Returns a specified number of contiguous contetn from the start of table content.
		/// </summary>
		/// <param name="size">The number of columns to return.</param>
		/// <returns>A Content that contains the specified number of elements from the start of the table content.</returns>
		public Content Take(int size)
		{
			try
			{
				var content = new Content();

				foreach (var item in _tableContent)
				{
					IEnumerable<string> contentTaken = item.Take(size);
					content._tableContent = content._tableContent.Append(contentTaken);
				}
				return content;
			}
			catch (Exception ex)
			when ((ex is ArgumentNullException) || (ex is NullReferenceException))
			{
				var content = new Content();

				return content;
			}
			catch (OutOfMemoryException)
			{
				throw;
			}
		}

		/// <summary>
		/// Bypasses a specified number of elements in a table and then returns the remaining contents.
		/// </summary>
		/// <param name="count">The number of columns to skip before returning the remaining elements.</param>
		/// <returns>A Content that contains the content that occur after the specified index in the input.</returns>
		public Content Skip(int count)
		{
			var content = new Content();

			foreach (var item in _tableContent)
			{
				IEnumerable<string> skipped = item.Skip(count);
				content._tableContent = content._tableContent.Append(skipped);
			}
			return content;

		}
	}
}
 