using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DllForm
{
    public partial class DllSampleForm : Form
    {
        public DllSampleForm()
        {
            InitializeComponent();

            this.Text = "HELLO, DIALOG";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This is sample form in DLL.",
                "SAMPLE FORM",
                MessageBoxButtons.OK);
        }
    }
}
