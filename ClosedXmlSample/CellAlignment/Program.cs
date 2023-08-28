using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellAlignment
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var alignment = new CellAlignment()
			{
				Path = @"./ClosedXml_alignment1.xlsx",
				Sheet = "AlignmentSample"
			};
			alignment.Alignment1();
		}
	}
}
