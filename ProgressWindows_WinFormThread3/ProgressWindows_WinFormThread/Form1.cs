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
            dataGridView1.DataSource = bindingSource;
        }

        public void OnWorkTaskFinished(object sender, EventArgs e)
        {
            _ = _worker.GetProgressAsync(4);
            startButton.Enabled = true;
        }

        public void OnProgressGet(object sender, EventArgs e)
        {
            var eventArg = e as ProgressGetEventArgs;
            var progress = eventArg.Progress;
            var items = progress.ToList();

            bindingSource.DataSource = progress;
            bindingSource.ResetBindings(false);
        }

        public void SetupDataBinding()
        {
            var dataItems = DataItem.Factory().ToList();

            bindingSource = new BindingSource();
            bindingSource.DataSource = dataItems;
            dataGridView1.DataSource = bindingSource;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
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
    }
}
