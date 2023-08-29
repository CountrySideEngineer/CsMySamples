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
				Path = @"./ClosedXml_ColWidth.xlsx",
				Sheet = "ColWidthSample"
			};
			colWidth.ColumnWidth1();
		}
	}
}
