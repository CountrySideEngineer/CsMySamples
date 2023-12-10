using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressWindows_WinFormThread
{
    internal class ProgressGetEventArgs : EventArgs
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProgressGetEventArgs() : base() { }

        /// <summary>
        /// Progress data informations
        /// </summary>
        public short[] Progress { get; set; }
    }
}
