using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSEng.XmlConverter.Model;

namespace CSEngXmlConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			var targetFile = args[0];
			var converter = new XmlConverter();
			try
			{
				var resultPath = converter.Convert(targetFile);
				Console.WriteLine($"New file path : {resultPath}");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return;
		}
	}
}
