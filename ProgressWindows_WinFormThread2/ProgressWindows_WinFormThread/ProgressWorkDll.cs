using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgressWindows_WinFormThread2
{
    internal static class ProgressWorkDll
    {
        [DllImport("ProgressWork.dll")]
        public static extern void InitProgress();

        [DllImport("ProgressWork.dll")]
        public static extern void GetProgresses(
            short[] progresses, 
            int progressNum, 
            ref int actProgressNum);

        [DllImport("ProgressWork.dll")]
        public static extern void RunProgress(
            short interval,
            DataItemTag[] items,
            int itemCount);

        [DllImport("ProgressWork.dll")]
        public static extern void GetResult(
            short[] results,
            int resultNum,
            ref int actResultNum);
    }
}
