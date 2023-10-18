using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressWindows_WinForm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			for (int index = 0;index < 100; index++)
			{
				if (true == backgroundWorker.CancellationPending)
				{
					e.Cancel = true;
					break;
				}
				else
				{
					backgroundWorker.ReportProgress(index + 1);
					Thread.Sleep(100);
				}
			}
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
