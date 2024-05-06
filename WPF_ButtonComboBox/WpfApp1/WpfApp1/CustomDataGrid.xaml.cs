using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1
{
	/// <summary>
	/// CustomDataGrid.xaml の相互作用ロジック
	/// </summary>
	public partial class CustomDataGrid : UserControl
	{
		public CustomDataGrid()
		{
			InitializeComponent();
		}

		private void FrameworkElement_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			Debug.WriteLine($"{nameof(FrameworkElement_PreviewMouseDown)} called.");

			var viewModel = (CustomDataGridViewModel)DataContext;
			Debug.WriteLine($"SampleIndex = {viewModel.SampleIndex}");
			Debug.WriteLine($"SelIndex2 = {viewModel.SelIndex2}");

			if (sender is ComboBox)
			{
				var comboBox = sender as ComboBox;
				comboBox.Text = "aaaa";
			}
			else if (sender is ComboBoxItem)
			{

				var comboBoxItem = sender as ComboBoxItem;
				((ComboBox)comboBoxItem.Parent).Text = "bbbb";
			}
			else
			{
				Debug.WriteLine("else case");

			}

		}

		public void MyComboBox_Selected(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine($"{sender}");

			var comboBoxItem = (ComboBoxItem)sender;
			var commandItem = (SampleCommandModel)(comboBoxItem.Content);
			commandItem.Execute();

			Debug.WriteLine(commandItem.Content);
		}

		private void MyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Debug.WriteLine($"{nameof(MyComboBox_SelectionChanged)} called.");

		}

		private void MyComboBox_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Debug.WriteLine($"{nameof(MyComboBox_MouseDown)} called.");
		}

		private void MyComboBox_PreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			Debug.WriteLine($"{sender}");

			if (sender is ComboBox)
			{
				var comboBox = sender as ComboBox;
				SampleCommandModel selectedItem = (SampleCommandModel)comboBox.SelectedItem;
				comboBox.Text = selectedItem?.Content;
				if (null != selectedItem)
				{
					Debug.WriteLine($"{selectedItem?.Content}");
				}
				else
				{
					Debug.WriteLine("selectedItem is null.");
				}

			}
		}
	}
}
