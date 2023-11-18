using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsAsyncCpp
{
    internal class ProgressInfo
    {
        public short Numerator { get; set; } = 0;
        public short Denominator { get; set; } = 0;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProgressInfo() { }
    }
}
