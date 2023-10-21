using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProgressWindows_WinForm.Form1;

namespace ProgressWindows_WinForm
{
	internal class Worker
	{
		public delegate void WorkProgressChangedEventHandler(object sender, EventArgs e);

		public delegate void WorkFinishedEventHandler(object sender, EventArgs e);

		public event WorkProgressChangedEventHandler OnWorkProgressChanged;

		public event WorkFinishedEventHandler OnWorkFinished;

		public static Worker worker = null;
		public IProgress<int> WorkerProgress { get; set; }

		public static void OnProgressNotify(int progress)
		{
			worker?.SendProgress(100);
		}

		public void SendProgress(int progress)
		{
			ProgressChanged(WorkerProgress);
		}

		public void ProgressChanged(IProgress<int> progress)
		{
			progress.Report(10);
		}

		public void DoWork(IEnumerable<TableItem> items)
		{
			worker = this;

			Task task = DoWorkAsycn(items);
		}

		protected virtual async Task DoWorkAsycn(IEnumerable<TableItem> items)
		{
			Task task = DoWorkTask(items);
			await task;
		}

		protected virtual Task DoWorkTask(IEnumerable<TableItem> items)
		{
			var notification = new ProgressNotification(OnProgressNotify);
			Task task = Task.Run(() =>
			{

				foreach (var item in items)
				{
					if (item.IsChecked)
					{
						ProgWork.BackgroundWork(notification);
					}
				}
			});
			return task;
		}
	}
}
