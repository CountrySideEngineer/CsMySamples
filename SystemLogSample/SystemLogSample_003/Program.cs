using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogSample_003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceName = "SystemLogSample";

            if (System.Diagnostics.EventLog.SourceExists(sourceName))
            {
                System.Diagnostics.EventLog.DeleteEventSource(sourceName);
            }
        }
    }
}
