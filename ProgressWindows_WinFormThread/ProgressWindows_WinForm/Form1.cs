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

		private Worker _worker = new Worker();

		public Form1()
		{
			InitializeComponent();
		}

		public Form1(int itemNum)
		{
			InitializeComponent();

			SetupTableItem(itemNum);

			_worker.OnWorkProgressChanged += OnProgressChanged;
			var progress = new Progress<int>(OnProgressChanged);
			_worker.WorkerProgress = progress;
		}

		protected void SetupTableItem(int itemNum)
		{
			_tableItems = TableItem.Factory(itemNum).ToList();

			_tableItemBindingSource = new BindingSource();
			_tableItemBindingSource.DataSource = _tableItems;
			ItemTableGridView.DataSource = _tableItemBindingSource;
		}

		int _progressChanged = 0;
		public void OnProgressChanged(object sender, EventArgs e)
		{
			_progressChanged++;

			string content = _progressChanged.ToString() + "%";
			Console.WriteLine(content);
			try
			{
				progressValue.Text = content;

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void OnProgressChanged(int prog)
		{
			string content = prog.ToString() + "%";
			Console.WriteLine(content);
			progressValue.Text = content;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			_progressChanged = 0;
			_worker?.DoWork(_tableItems);
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
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
