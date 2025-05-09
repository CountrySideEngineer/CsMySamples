using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MultiWindow.Command;

namespace WPF_MultiWindow.ViewModel
{
    internal class WindowViewModel : ViewModelBase
    {
        public delegate void NotifyClosingWindow(object sender, EventArgs e);
        public NotifyClosingWindow? NotifyClosingWindowDelegate;

        public delegate void CloseWindowDelegate(object sender, EventArgs e);
        public event CloseWindowDelegate? CloseWindowEvent;


        protected DelegateCommand? _closeWindowCommand = null;
        public DelegateCommand CloseWindowCommand
        {
            get
            {
                if (null == _closeWindowCommand)
                {
                    _closeWindowCommand = new DelegateCommand(CloseWindowCommandExecute);

                }
                return _closeWindowCommand;
            }
        }

        public virtual void OnClosingWindowEventHandler(object sender, EventArgs e)
        {
            NotifyClosingWindowDelegate?.Invoke(this, e);
        }

        protected virtual void RaiseCloseWindowEvent()
        {
            CloseWindowEvent?.Invoke(this, new EventArgs());
        }

        public virtual void CloseWindowCommandExecute()
        {
            RaiseCloseWindowEvent();
        }

        public virtual void ClosingWindowCommandExecute()
        {
            RaiseCloseWindowEvent();
        }
    }
}
