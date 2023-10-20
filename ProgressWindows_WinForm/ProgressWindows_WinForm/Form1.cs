using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressWindows_WinForm
{
	public partial class Form1 : Form
	{
		public delegate void ProgressNotification(int progress);

		protected BindingSource _tableItemBindingSource;
		protected IEnumerable<TableItem> _tableItems;

		public Form1()
		{
			InitializeComponent();
		}

		public Form1(int itemNum)
		{
			InitializeComponent();

			SetupTableItem(itemNum);
		}

		protected void SetupTableItem(int itemNum)
		{
			_tableItems = TableItem.Factory(itemNum);

			_tableItemBindingSource = new BindingSource();
			_tableItemBindingSource.DataSource = _tableItems;
			ItemTableGridView.DataSource = _tableItemBindingSource;
		}

		public static int _progress = 0;
		public static bool _isContinue = false;
		public static void OnProgressNotification(int progress)
		{
			_progress = progress;
			if (100 <= _progress)
			{
				_isContinue = false;
			}
			else
			{
				_isContinue = true;
			}
		}

		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var notification = new ProgressNotification(OnProgressNotification);
			ProgWork.BackgroundWorkAsync(notification);
			Form1._isContinue = true;

			while (_isContinue)
			{
				if (backgroundWorker.CancellationPending)
				{
					e.Cancel = true;
					ProgWork.BackgroundWorkCancle();
					break;
				}
				backgroundWorker.ReportProgress(_progress);
				Thread.Sleep(10);
			}

			bool isRunning = false;
			do
			{
				isRunning = ProgWork.GetBackgroundWorkState();
			} while (isRunning);
		}

		private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressValue.Text = e.ProgressPercentage.ToString() + "%";
		}

		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (true == e.Cancelled)
			{
				progressValue.Text = "canceled";
			}
			else if (null != e.Error)
			{
				progressValue.Text = "failed";
			}
			else
			{
				progressValue.Text = "DONE!";
			}

			buttonStart.Enabled = true;
			buttonCancel.Enabled = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (false == backgroundWorker.IsBusy)
			{
				backgroundWorker.RunWorkerAsync();
				buttonCancel.Enabled = true;
				buttonStart.Enabled = false;
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			if (true == backgroundWorker.WorkerSupportsCancellation)
			{
				backgroundWorker.CancelAsync();
			}
		}
	}
}
