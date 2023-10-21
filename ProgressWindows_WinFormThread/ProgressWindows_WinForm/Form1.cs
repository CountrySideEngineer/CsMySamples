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
		protected List<TableItem> _tableItems;

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
			_tableItems = TableItem.Factory(itemNum).ToList();

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

		int _itemIndex = 0;
		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var notification = new ProgressNotification(OnProgressNotification);

			_itemIndex = 0;
			foreach (var item in _tableItems)
			{
				_isContinue = true;
				_progress = 0;
				if (item.IsChecked)
				{
					ProgWork.BackgroundWorkAsync(notification);
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
					backgroundWorker.ReportProgress(_progress);

					bool isRunning = false;
					do
					{
						isRunning = ProgWork.GetBackgroundWorkState();
					} while (isRunning);
				}
				_itemIndex++;
			}
		}

		private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			try
			{
				progressValue.Text = e.ProgressPercentage.ToString() + "%";
				ItemTableGridView.Rows[_itemIndex].Cells[3].Value = e.ProgressPercentage;
			}
			catch (Exception)
			{
				Console.WriteLine("Exception detected.!");
			}
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

		private void Form1_Load(object sender, EventArgs e)
		{
			//Add progress column.
			var progColumn = new DataGridViewProgressBarColumn();
			progColumn.DataPropertyName = "progress";
			progColumn.Name = "progress";
			progColumn.HeaderText = "progress";
			ItemTableGridView.Columns.Add(progColumn);
		}
	}
}
