using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndRefType_001
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int sampleValue = 20;

			SampleMethod(sampleValue);

			Console.WriteLine($"sampleValue = {sampleValue}");

			return;
		}

		static void SampleMethod(int sampleValue)
        {
			sampleValue = 22;

			Console.WriteLine($"sampleValue = {sampleValue}");
        }
    }
}
