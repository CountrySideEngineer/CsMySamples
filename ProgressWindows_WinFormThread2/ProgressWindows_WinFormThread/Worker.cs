using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressWindows_WinFormThread2
{
    internal class Worker
    {
        public delegate void WorkTaskFinishedEventHandler(object sender, EventArgs e);
        public event WorkTaskFinishedEventHandler WorkTaskFinished;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Worker() { }

        public async Task RunAsync()
        {
            await Task.Run(() =>
            {
                ProgressWorkDll.RunProgress(53);
            });

            WorkTaskFinished?.Invoke(this, null);
        }

        public void InitProgress()
        {
            ProgressWorkDll.InitProgress();
        }

        public void GetProgress(int count, out short[] progressData)
        {
            progressData = new short[count];
            int actCount = -1;

            ProgressWorkDll.GetProgresses(progressData, count, ref actCount);
        }
    }
}
