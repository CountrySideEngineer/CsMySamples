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
using WPF_XmlTreeView.NET.Model;
using WPF_XmlTreeView.NET.ViewModel;

namespace WPF_XmlTreeView.NET
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			MainWindowViewModel viewModel = (MainWindowViewModel)DataContext;
			viewModel.SelectedItem = (ProjectItem)e.NewValue;

        }
    }
}