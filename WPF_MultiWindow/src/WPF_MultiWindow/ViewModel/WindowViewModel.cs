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

        public delegate void ClosingWindowDelegate(object sender, EventArgs e);
        public event ClosingWindowDelegate? ClosingWindowEvent;

        public virtual void OnClosingWindowEventHandler(object sender, EventArgs e)
        {
            NotifyClosingWindowDelegate?.Invoke(this, e);
        }

        protected virtual void RaiseClosingWindowEvent()
        {
            ClosingWindowEvent?.Invoke(this, new EventArgs());
        }

        public virtual void ClosingWindowCommandExecute()
        {
            RaiseClosingWindowEvent();
        }
    }
}
