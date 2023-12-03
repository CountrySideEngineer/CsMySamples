using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressWindows_WinFormThread
{
    public partial class Form1 : Form
    {
        internal Worker _worker = new Worker();
        public Form1()
        {
            InitializeComponent();

            SetupDataBinding();
            SetupTimer();

            _worker.WorkTaskFinished += OnWorkTaskFinished;
            _worker.ProgressGet += OnProgressGet;
        }

        public void OnWorkTaskFinished(object sender, EventArgs e)
        {
            _ = _worker.GetProgressAsync(4);
            startButton.Enabled = true;

            progressCheckTimer.Stop();
        }

        public void OnProgressGet(object sender, EventArgs e)
        {
            var eventArg = e as ProgressGetEventArgs;
            var progress = eventArg.Progress;

            List<DataItem> newDatas = ConvertProgress(progress).ToList();

            bindingSource.DataSource = newDatas;
            bindingSource.ResetBindings(false);
        }

        public void SetupDataBinding()
        {
            var dataItems = DataItem.Factory().ToList();

            bindingSource.DataSource = dataItems;
            bindingSource.ResetBindings(false);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _ = _worker.RunAsync((List<DataItem>)bindingSource.DataSource);

            progressCheckTimer.Start();
            startButton.Enabled = false;
        }

        private void SetupTimer()
        {
            progressCheckTimer.Tick += (s, arg) =>
            {
                _ = _worker.GetProgressAsync(4);
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private IEnumerable<DataItem> ConvertProgress(short[] progresses)
        {
            var dataSource = (IEnumerable<DataItem>)bindingSource.DataSource;
            int itemIndex = 0;
            foreach (var item in dataSource)
            {
                int progress = 0;

                try
                {
                    progress = progresses[itemIndex];
                }
                catch (IndexOutOfRangeException)
                {
                    progress = 0;
                }

                var newItem = new DataItem()
                {
                    IsChecked = item.IsChecked,
                    Name = item.Name,
                    Progress = progress,
                    StatusCode = item.StatusCode
                };
                itemIndex++;
                yield return newItem;
            }
        }
    }
}
