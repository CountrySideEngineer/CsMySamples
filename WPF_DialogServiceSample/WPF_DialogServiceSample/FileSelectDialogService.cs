using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_DialogServiceSample
{
    internal class FileSelectDialogService : IDialogService<IEnumerable<string>>
    {
        public Window? Owner { get; set; } = null;

        public virtual bool? ShowDialog(IEnumerable<string> context)
        {
            var openFileDlg = new OpenFileDialog()
            {
                Multiselect = true
            };

            bool? dlgResult = openFileDlg.ShowDialog(Owner);
            if (true == dlgResult)
            {
                Debug.WriteLine(openFileDlg.FileNames.Length);
                List<string> fileStore = (List<string>)context;
                fileStore.Clear();
                foreach (var item in openFileDlg.FileNames)
                {
                    Debug.WriteLine(item);
                    fileStore.Add(item);
                }
            }

            return dlgResult;
        }
    }
}
