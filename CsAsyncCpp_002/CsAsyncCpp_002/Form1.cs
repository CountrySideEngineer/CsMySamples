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
        long _timer1Count = 0;
        long _itmer2Count = 0;

        public Form1()
        {
            InitializeComponent();

            SetUpTimer();
        }

        protected void SetUpTimer()
        {
            progressTimer1.Enabled = false;
            progressTimer2.Enabled = false;

            progressTimer1.Tick += (sender, e) =>
            {
                Console.WriteLine("TIMER1 - ticked");
            };
            progressTimer2.Tick += (sender, e) =>
            {
                Console.WriteLine("TIMER2 - ticked");
            };
        }

        private void startTimerButton1_Click(object sender, EventArgs e)
        {
            progressTimer1.Start();
        }

        private void startTimerButton2_Click(object sender, EventArgs e)
        {
            progressTimer2.Start();
        }
    }
}
