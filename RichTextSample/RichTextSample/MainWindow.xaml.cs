using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RichTextSample
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void richTextBox_SelectionChanged(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!richTextBox.Selection.IsEmpty)
				{
					var endPos = richTextBox.Selection.End;
					var startPos = richTextBox.Selection.Start;
					var range = new TextRange(startPos, endPos);
					range.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.DarkBlue);
				}
			}
			catch (Exception) { }
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			RichTextSampleViewModel vm = (RichTextSampleViewModel)DataContext;
			vm.LoadContent();
		}
	}
}
