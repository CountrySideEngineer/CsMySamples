using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubFormDll
{
    public partial class SubForm : Form
    {
        public SubForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = Properties.Resources.ID_SUB_FORM_MESSAGE;
            string title = Properties.Resources.ID_SUB_FORM_TITLE;

            MessageBox.Show(message, title, MessageBoxButtons.OK);
        }
    }
}
