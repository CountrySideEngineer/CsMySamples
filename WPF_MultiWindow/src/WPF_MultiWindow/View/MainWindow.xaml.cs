using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_MultiWindow.Service;
using WPF_MultiWindow.View;
using WPF_MultiWindow.ViewModel;

namespace WPF_MultiWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IWindowService<SubWindowViewModel> service = new SubWindowService<SubWindow, SubWindowViewModel>()
            {
                Owner = this
            };
            this.DataContext = new MainWindowViewModel()
            {
                WindowService = service
            };
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WindowViewModel? viewModel = DataContext as WindowViewModel;
            viewModel?.ClosingWindowCommandExecute();
        }
    }
}