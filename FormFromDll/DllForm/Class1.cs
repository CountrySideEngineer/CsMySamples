using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DllForm
{
    public class Class1
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Class1() { }

        public void ShowForm()
        {
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(false, "SAMPLE_STRING_DATA"))
            {
                // 二重起動を禁止する
                if (mutex.WaitOne(0, false))
                {
                    var form = new DllSampleForm();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        "MULTIPLE START IS NOT ALLOWED.",
                        "MULTIPLE START ERROR",
                        MessageBoxButtons.OK
                        );
                }
            }
        }
    }
}
