using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MultiWindow.Command;

namespace WPF_MultiWindow.ViewModel
{
    internal abstract class WindowViewModel : ViewModelBase
    {
        public abstract void ClosingWindowCommandExecute();
    }
}
