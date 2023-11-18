using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsAsyncCpp
{
    public partial class Form1 : Form
    {
        Worker worker;

        IProgress<ProgressInfo> _progress;
        IProgress<int> _notifyResult;

        public Form1()
        {
            InitializeComponent();

            _progress = new Progress<ProgressInfo>(e =>
            {
                if (0 != e.Denominator)
                {
                    progressLabel.Text = $"{e.Numerator} / {e.Denominator}";
                    progressBar.Value = (100 * e.Numerator / e.Denominator);
                }
            });
            _notifyResult = new Progress<int>(e =>
            {
                resultLabel.Text = $"ResultCode : {e:d5}";
            });
            worker = new Worker
            {
                Progress = _progress,
                Result = _notifyResult
            };

            resultLabel.Text = string.Empty;
        }

        private void btnExecuteProcess_Click(object sender, EventArgs e)
        {
            _ = worker.RunAsync();
        }
    }
}
