using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MultiWindow.Command;
using WPF_MultiWindow.Service;

namespace WPF_MultiWindow.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public IWindowService<SubWindowViewModel>? WindowService { get; set; } = null;

        protected DelegateCommand? _openNewDialogCommand { get; set; } = null;

        public DelegateCommand OpenNewDialogCommand
        {
            get
            {
                if (null == _openNewDialogCommand)
                {
                    _openNewDialogCommand = new DelegateCommand(OpenNewDialogCommandExecute);
                }
                return _openNewDialogCommand;
            }
        }

        public virtual void OpenNewDialogCommandExecute()
        {
            var subViewModel = new SubWindowViewModel();
            WindowService?.ShowNew(subViewModel);
        }
    }
}
