using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CsSideSampleProgram
{
    public struct SAMPLE_STRUCT
    {
        public short ParamA { get; set; }
        public short ParamB { get; set; }
        public int Result { get; set; }
    };

    public static class CppSideIF
    {
        [DllImport("CppSideSampleDll.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern short CppSideSampleIF(ref SAMPLE_STRUCT input);
        [DllImport("CppSideSampleDll.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern short CppSideSampleIF2(short inputA, short inputB);
    }
}
