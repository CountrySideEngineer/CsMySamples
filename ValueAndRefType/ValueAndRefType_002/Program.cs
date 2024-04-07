using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndRefType_002
{
	public class SampleClass
	{
		public SampleClass()
		{
			SampleValue = 0;
		}

		public int SampleValue { get; set; }
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			var sampleClass = new SampleClass()
			{
				SampleValue = 20
			};
			Console.WriteLine($"In Main : SampleValue = {sampleClass.SampleValue} ");

			SampleMethod(sampleClass);

			Console.WriteLine($"In Main : SampleValue = {sampleClass.SampleValue} ");
		}

		static void SampleMethod(SampleClass sampleClass)
		{
			sampleClass.SampleValue = 22;

			Console.WriteLine($"In Sub  : SampleValue = {sampleClass.SampleValue} ");
		}
	}
}
