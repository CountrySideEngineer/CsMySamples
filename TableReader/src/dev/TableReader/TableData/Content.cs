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
	}
}
