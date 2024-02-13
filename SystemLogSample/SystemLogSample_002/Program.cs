using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogSample_002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
            //eventLog.MachineName = ".";
            eventLog.Log = "Sample";
            eventLog.Source = "SytemLogSample";

            if (!System.Diagnostics.EventLog.SourceExists(eventLog.Source))
            {
                var eventData = 
                    new System.Diagnostics.EventSourceCreationData(eventLog.Source, eventLog.Log);
                eventData.MachineName = eventLog.MachineName;
                System.Diagnostics.EventLog.CreateEventSource(eventData);
            }
            //eventLog.WriteEntry("サンプルイベントメッセージ", System.Diagnostics.EventLogEntryType.Information, 2, 3);
            eventLog.WriteEntry("サンプルイベントメッセージ");
        }
    }
}
