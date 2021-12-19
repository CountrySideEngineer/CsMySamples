using Microsoft.TeamFoundation.Common.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoadNativeDllSample
{
	class Program
	{
		[DllImport("kernel32.dll")]
		static extern IntPtr LoadLibrary(string lpFileName);
		[DllImport("kernel32.dll", CallingConvention=CallingConvention.Cdecl)]
		static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
		[DllImport("kernel32.dll")]
		static extern bool FreeLibrary(IntPtr hLibModule);

		delegate int AddDelegate(int value1, int value2);
		delegate int SumDelegate(IntPtr values, int valueCount);

		static void Main(string[] args)
		{
			// 関数ポインタを取得
			string dllPath = @"E:\development\VisualStudioSample\CsMySamples\LoadNativeDynamicLinkLibrary\bin\x64\Debug\LoadNativeDynamicLinkLibrary.dll";

			IntPtr ptrLib = LoadLibrary(dllPath);
			IntPtr ptrAdd = GetProcAddress(ptrLib, "Add");

			AddDelegate addDelegate = (AddDelegate)Marshal.GetDelegateForFunctionPointer(ptrAdd, typeof(AddDelegate));
			int value1 = 10;
			int value2 = 23;
			int addedValue = addDelegate(value1, value2);
			Console.WriteLine($"addedValue = {addedValue}");

			//IntPtr ptrSum = GetProcAddress(ptrLib, "Sum");
			//SumDelegate sumDelegate = (SumDelegate)Marshal.GetDelegateForFunctionPointer(ptrSum, typeof(SumDelegate));
			//int valuesCount = 3;
			//IntPtr values = new IntPtr();
			//values = Marshal.AllocHGlobal(valuesCount * sizeof(int));
			//unsafe
			//{
			//	int* valuesPtr = (int*)values;
			//	for (int index = 0; index < valuesCount; index++)
			//	{
			//		*(valuesPtr + index) = (index + 1);
			//	}
			//}
			//int sumValue = sumDelegate(values, 3);
			//Console.WriteLine($"theSum = {sumValue}");

			//Marshal.FreeHGlobal(values);
			FreeLibrary(ptrLib);
			ptrLib = IntPtr.Zero;

			//MK2実行
			dllPath = @"E:\development\VisualStudioSample\CsMySamples\LoadNativeDynamicLinkLibrary\bin\x64\Debug\LoadNativeDynamicLinkLibrary_Mk2.dll";
			ptrLib = LoadLibrary(dllPath);
			ptrAdd = GetProcAddress(ptrLib, "Add");
			addDelegate = (AddDelegate)Marshal.GetDelegateForFunctionPointer(ptrAdd, typeof(AddDelegate));
			value1 = 21;
			value2 = 43;
			addedValue = addDelegate(value1, value2);
			Console.WriteLine($"addedValue = {addedValue}");
			FreeLibrary(ptrLib);

			return;
		}
	}
}
