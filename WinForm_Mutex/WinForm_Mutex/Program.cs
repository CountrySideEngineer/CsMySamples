using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Mutex
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Count() < 1)
            {
                MessageBox.Show(
                    "Command line argument invalid.", 
                    "ERROR", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            string mutexName = $"MUTEXT_NAME_{args[0]}";
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(false, mutexName))
            {
                if (mutex.WaitOne(0, false))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                else
                {
                    MessageBox.Show(
                        "Multiple start is not allowed.",
                        "Multiple start error.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }


        }
    }
}
