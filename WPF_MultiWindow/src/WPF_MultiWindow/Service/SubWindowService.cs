using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MultiWindow.ViewModel;

namespace WPF_MultiWindow.Service
{
    internal class SubWindowService<TWindow, TViewModel> : IWindowService<TViewModel>
        where TWindow : Window, new()
        where TViewModel : WindowViewModel, new()
    {
        public Window? Owner { get; set; } = null;

        public void Close(TViewModel context)
        {
            throw new NotImplementedException();
        }

        protected List<TWindow> _windows = [];

        public void CloseAll()
        {
            foreach (var window in _windows)
            {
                window.Close();
            }
        }

        public bool? ShowNew(TViewModel context)
        {
            var window = new TWindow()
            {
                //Owner = Owner,
                DataContext = context
            };
            _windows.Add(window);

            window.Show();

            return true;
        }
    }
}
