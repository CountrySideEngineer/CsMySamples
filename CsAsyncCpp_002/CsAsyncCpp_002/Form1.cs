using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CsAsyncCpp_002
{
    public partial class Form1 : Form
    {
        Worker _worker = null;

        public Form1()
        {
            InitializeComponent();

            SetUpTimer();

            _worker = new Worker();

            _worker.TaskFinishedEvent += OnTaskFinished;
        }

        public void OnTaskFinished(object sender, EventArgs e)
        {
            startTimerButton1.Enabled = true;
            startTimerButton2.Enabled = true;

            progressTimer1.Stop();
            progressTimer2.Stop();
        }

        protected void SetUpTimer()
        {
            progressTimer1.Enabled = false;
            progressTimer2.Enabled = false;

            progressTimer1.Tick += (sender, e) =>
            {
                short progress = _worker.GetProgress();

                progressBar1.Value = progress;
            };
            progressTimer2.Tick += (sender, e) =>
            {
                short progress = 0;

                _worker.GetProgress(ref progress);

                progressBar1.Value = progress;
            };
        }

        private void startTimerButton1_Click(object sender, EventArgs e)
        {
            startTimerButton1.Enabled = false;
            startTimerButton2.Enabled = false;

            progressTimer1.Start();

            _ = _worker.RunTask();
        }

        private void startTimerButton2_Click(object sender, EventArgs e)
        {
            startTimerButton1.Enabled = false;
            startTimerButton2.Enabled = false;

            progressTimer2.Start();

            _ = _worker.RunTask();
        }
    }
}
