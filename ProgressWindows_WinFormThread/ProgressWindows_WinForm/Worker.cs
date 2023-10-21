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
		public delegate void WorkProgressChangedEventHandler(object sender, ProgressChangedEventArgs e);

		public delegate void WorkFinishedEventHandler(object sender, EventArgs e);

		public event WorkProgressChangedEventHandler OnWorkProgressChanged;

		public event WorkFinishedEventHandler OnWorkFinished;

		int _currentStageIndex = 0;
		string _currentStageName = string.Empty;
		bool _isContinue = false;

		public static Worker worker = null;
		public IProgress<WorkState> WorkerProgress { get; set; }

		public static void OnProgressNotify(int progress)
		{
			worker?.OnProgressChanged(progress);
		}

		public void OnProgressChanged(int progress)
		{
			var state = new WorkState()
			{
				ProgressPercentage = progress,
				StageIndex = _currentStageIndex,
				Name = _currentStageName
			};
			WorkerProgress.Report(state);
		}

		public void DoWork(IEnumerable<TableItem> items)
		{
			worker = this;

			Task task = DoWorkAsycn(items);
		}

		public void CancelWork()
		{
			_isContinue = false;
		}

		protected virtual async Task DoWorkAsycn(IEnumerable<TableItem> items)
		{
			await DoWorkTask(items);

			OnWorkFinished?.Invoke(this, null);
		}

		protected virtual Task DoWorkTask(IEnumerable<TableItem> items)
		{
			_isContinue = true;

			var notification = new ProgressNotification(OnProgressNotify);
			Task task = Task.Run(() =>
			{
				_currentStageIndex = 0;
				foreach (var item in items)
				{
					if (item.IsChecked)
					{
						_currentStageName = item.Name;
						ProgWork.BackgroundWork(notification);
					}
					_currentStageIndex++;

					if (!_isContinue)
					{
						break;
					}
				}
			});
			return task;
		}
	}
}
