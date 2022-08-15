using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableReader.TableData;

namespace TableReader.Interface
{
	public interface ITableReader
	{
		Range FindFirstItem(string item);

		Range FindFirstItem(string item, Range range);

		Range FindFirstItemInRow(string item, Range range);

		Range FindFirstItemInColumn(string item, Range range);

		IEnumerable<Range> FindItem(string item);

		IEnumerable<string> ReadRow(Range range);

		IEnumerable<string> ReadColumn(Range range);

		void GetMergedCellRange(ref Range range);

		void GetRowRange(ref Range range);

		void GetColumnRange(ref Range range);

		void GetTableRange(ref Range range);
	}
}
