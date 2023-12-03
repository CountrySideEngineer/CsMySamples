using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressWindows_WinFormThread
{
    internal struct DataItemTag
    {
        public short IsChecked { get; set; }

        public int Progress { get; set; }

        public ulong Result { get; set; }
    }

    internal class DataItem
    {
        public bool IsChecked { get; set; } = false;

        public string Name { get; set; } = string.Empty;

        public int Progress { get; set; } = 0;

        public ulong Result { get; set; } = 0;

        public string ResultCode {
            get
            {
                string _resultCode = $"0x{Result:X8}";
                return _resultCode;
            }
        }

        public ulong StatusCode { get; set; }

        public string Status
        {
            get
            {
                return $"0x{StatusCode:X4}";
            }
        }

        public DataItemTag ToStruct()
        {
            var tag = new DataItemTag()
            {
                IsChecked = this.IsChecked == true ? (short)1 : (short)0,
                Progress = this.Progress,
                Result = this.Result
            };
            return tag;
        }

        public static IEnumerable<DataItem> Factory()
        {
            for (int index = 0; index < 4; index++)
            {
                yield return new DataItem()
                {
                    IsChecked = false,
                    Name = $"sample data 0x{index:X4}",
                    Progress = 0,
                    StatusCode = 0
                };
            }
        }
    }
}
