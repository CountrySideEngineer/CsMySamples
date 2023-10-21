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

			var progress = new Progress<WorkState>(OnProgressChanged);
			_worker.WorkerProgress = progress;
		}

		protected void SetupTableItem(int itemNum)
		{
			_tableItems = TableItem.Factory(itemNum).ToList();

			_tableItemBindingSource = new BindingSource();
			_tableItemBindingSource.DataSource = _tableItems;
			ItemTableGridView.DataSource = _tableItemBindingSource;
		}

		internal void OnProgressChanged(WorkState progressState)
		{
			progressValue.Text = progressState.ProgressPercentage.ToString() + "%";

			int rowIndex = progressState.StageIndex;
			ItemTableGridView.Rows[rowIndex].Cells[3].Value = progressState.ProgressPercentage;
		}

		private void button1_Click(object sender, EventArgs e)
		{
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
