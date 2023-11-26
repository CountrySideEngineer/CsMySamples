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

        public void GetProgress(int count, out short[] progressData)
        {
            progressData = new short[count];
            int actCount = -1;

            ProgressWorkDll.GetProgresses(progressData, count, ref actCount);
        }

        public IEnumerable<DataItem> GetInformation(IEnumerable<DataItem> items)
        {
            int actCount = -1;
            int count = items.Count();
            short[] progress = new short[count];
            short[] result = new short[count];

            ProgressWorkDll.GetProgresses(progress, count, ref actCount);
            ProgressWorkDll.GetResult(result, count, ref actCount);

            for (int index = 0; index < actCount; index++)
            {
                var progItem = progress[index];
                var resultItem = result[index];

                var dataItem = new DataItem()
                {
                    IsChecked = items.ElementAt(index).IsChecked,
                    Name = items.ElementAt(index).Name,
                    Progress = progItem,
                    Result = Convert.ToUInt64(resultItem)
                };
                yield return dataItem;
            }
        }
    }
}
