using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsAsyncCpp
{
    internal class Worker
    {
        protected static Worker _worker = null;
        public static void OnProgressChanged(short numerator, short denominator)
        {
            _worker?.Progress?.Report(new ProgressInfo()
            {
                Numerator = (short)numerator,
                Denominator = (short)denominator
            });
        }

        public static void OnResultNotification(ulong result)
        {
            _worker?.Result?.Report((short)result);
        }

        public static Worker GetInstance()
        {
            if (null == _worker)
            {
                _worker = new Worker();
            }
            return _worker;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected Worker() { }

        public IProgress<ProgressInfo> Progress { get; set; }
        public IProgress<int> Result { get; set; }

        public async Task RunAsync()
        {
            await Task.Run(() =>
            {
                CppDll.SetResultCallback(OnResultNotification);
                CppDll.SetProgressCallback(OnProgressChanged);
                CppDll.Process();
            });
        }
    }
}
