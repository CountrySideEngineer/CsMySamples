using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsAsyncCpp_002
{
    public static class CppDlls
    {
        [DllImport("CppDll.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern byte GetProgressByReturn();

        [DllImport("CppDll.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GetProgressByPointer(ref byte progress);

        [DllImport("CppDll.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Process(byte span);
    }
}
