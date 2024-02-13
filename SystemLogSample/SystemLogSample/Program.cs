using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceName = "SystemLogSample";

            if (!System.Diagnostics.EventLog.SourceExists(sourceName))
            {
                System.Diagnostics.EventLog.CreateEventSource(sourceName, "System");
            }

            byte[] myData = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //イベントログにエントリを書き込む
            //ここではエントリの種類をエラー、イベントIDを1、分類を1000とする
            System.Diagnostics.EventLog.WriteEntry(
                sourceName, "イベントログに書き込む文字列",
                System.Diagnostics.EventLogEntryType.Error, 1, 1000, myData);
        }
    }
}
