using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPaintingSample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var paint = new CellPainter()
			{
				Path = @"./ClosedXml_sample1.xlsx",
				Sheet = "PaintSample"
			};
			paint.Paint1();

			paint.Path = @"./ClosedXml_sample2.xlsx";
			paint.Paint2();

			paint.Path = @"./ClosedXml_sample3.xlsx";
			paint.Paint3();

			paint.Path = @"./ClosedXml_sample4.xlsx";
			paint.Paint4();
		}
	}
}
