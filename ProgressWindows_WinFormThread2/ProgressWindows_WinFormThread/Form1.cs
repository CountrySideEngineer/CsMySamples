using ProgressWindows_WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressWindows_WinFormThread2
{
    public partial class Form1 : Form
    {
        Worker _worker;

        public Form1()
        {
            InitializeComponent();

            SetupDataBinding();
            SetupTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _worker = new Worker();
        }

        List<DataItem> _dataItems;

        public void SetupDataBinding()
        {
            _dataItems = DataItem.Factory().ToList();

            tableItemBindingSource = new BindingSource();
            tableItemBindingSource.DataSource = _dataItems;
            dataView.DataSource = tableItemBindingSource;
        }

        public void SetupTimer()
        {
            progressCheckTimer.Tick += (sender, e) =>
            {
                IEnumerable<DataItem> updateItem = _worker.GetInformation(_dataItems);
                _dataItems = updateItem.ToList();
                tableItemBindingSource.DataSource = _dataItems;

                tableItemBindingSource.ResetBindings(false);
            };
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            progressCheckTimer.Start();
            _ = _worker.RunAsync();
        }

    }
}
