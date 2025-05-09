using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_MultiWindow.ViewModel;

namespace WPF_MultiWindow.View
{
    /// <summary>
    /// SubWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SubWindow : Window
    {
        public SubWindow()
        {
            InitializeComponent();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var context = (SubWindowViewModel)e.NewValue;
            context.NotifyClosingWindowDelegate += OnNotifyClosingWindowEventHandler;
        }

        private void OnNotifyClosingWindowEventHandler(object sender, EventArgs e)
        {
            Debug.WriteLine($"{nameof(OnNotifyClosingWindowEventHandler)} called.");

            this.Close();
        }
    }
}
