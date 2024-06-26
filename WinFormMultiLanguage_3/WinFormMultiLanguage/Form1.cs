﻿using System;
using System.Threading;
using System.Windows.Forms;
using WinFormMultiLanguage.Properties;

namespace WinFormMultiLanguage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pushMeButton_Click(object sender, EventArgs e)
        {
            string message = Properties.Resources.ID_MESSAGE_BOX_MESSAGE;
            string title = Properties.Resources.ID_MESSAGE_BOX_TITLE;

            MessageBox.Show(message, title, MessageBoxButtons.OK);

            var subFormIF = new SubFormDll.SubFormIF();
            subFormIF.ShowDialog();
        }
    }
}
