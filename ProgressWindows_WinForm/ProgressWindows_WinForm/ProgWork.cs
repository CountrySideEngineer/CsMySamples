using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static ProgressWindows_WinForm.Form1;

namespace ProgressWindows_WinForm
{
	public class ProgWork
	{
		[DllImport("ProgWork.dll")]
		public static extern void BackgroundWorkAsync(ProgressNotification notify);

		[DllImport("ProgWork.dll")]
		public static extern void BackgroundWork(ProgressNotification notify);

		[DllImport("ProgWork.dll")]
		public static extern void BackgroundWorkCancle();

		[DllImport("ProgWork.dll")]
		public static extern bool GetBackgroundWorkState();

		[DllImport("ProgWork.dll")]
		public static extern void GetName(int parameter, byte[] buffer, short bufferSize);

		[DllImport("ProgWork.dll")]
		public static extern void GetParameter(int parameter, ref int param);
	}
}
