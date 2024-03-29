﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressWindows_WinFormThread
{
    internal class Worker
    {
        public delegate void WorkTaskFinishedEventHandler(object sender, EventArgs e);
        public event WorkTaskFinishedEventHandler WorkTaskFinished;

        public delegate void ProgressGetEventHandler(object sender, EventArgs e);
        public event ProgressGetEventHandler ProgressGet;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Worker() { }

        public async Task RunAsync(IEnumerable<DataItem> items)
        {
            await Task.Run(() =>
            {
                int count = items.Count();
                DataItemTag[] itemTags = new DataItemTag[count];
                for (int index = 0; index < count; index++)
                {
                    itemTags[index] = items.ElementAt(index).ToStruct();
                }

                InitProgress();

                ProgressWorkDll.RunProgress(20, itemTags, count);
            });

            WorkTaskFinished?.Invoke(this, null);
        }

        public void InitProgress()
        {
            ProgressWorkDll.InitProgress();
        }

        public virtual async Task GetProgressAsync(int count)
        {
            short[] progress = null;
            await Task.Run(() =>
            {
                GetProgress(count, out progress);
            });
            var eventArg = new ProgressGetEventArgs()
            {
                Progress = progress
            };
            ProgressGet?.Invoke(this, eventArg);
        }

        public void GetProgress(int count, out short[] progressData)
        {
            progressData = new short[count];
            int actCount = -1;

            ProgressWorkDll.GetProgresses(progressData, count, ref actCount);
        }
    }
}
