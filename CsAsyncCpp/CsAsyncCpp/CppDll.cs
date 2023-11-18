using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsAsyncCpp
{
    public static class CppDll
    {
        public delegate void ProgressCallback(short numerator, short denominator);
        public delegate void ResultCallback(ulong result);

        [DllImport("CppDll.dll")]
        public static extern void Process();

        [DllImport("CppDll.dll")]
        public static extern void SetProgressCallback(ProgressCallback callback);

        [DllImport("CppDll.dll")]
        public static extern void SetResultCallback(ResultCallback callback);
    }
}
