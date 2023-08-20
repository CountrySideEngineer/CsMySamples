using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellDrawingSample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var drawer = new DrawRuledLine()
			{
				Path = @"./ClosedXml_sample.xlsx",
				Sheet = "DrawSample"
			};
			drawer.Draw4();

			return;
		}
	}
}
