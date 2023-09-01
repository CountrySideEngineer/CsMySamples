using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColumnWidth
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var colWidth = new ColWidth()
			{
				Path = @"./ClosedXml_ColWidth1.xlsx",
				Sheet = "ColWidthSample"
			};
			colWidth.ColumnWidth1();

			colWidth.Path  = @"./ClosedXml_ColWidth2.xlsx";
			colWidth.ColumnWidth2();
		}
	}
}
