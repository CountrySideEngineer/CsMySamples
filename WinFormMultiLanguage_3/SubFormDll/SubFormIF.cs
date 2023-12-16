using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubFormDll
{
    public class SubFormIF
    {
        public void ShowDialog()
        {
            var form = new SubForm();
            form.ShowDialog();
        }


    }
}
