using CSEng.ViewModel;
using CSEng.XmlConverterGui.ViewModel;
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

namespace XmlConverterGui
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void TextBox_Drop(object sender, DragEventArgs e)
		{
			string[] dropFiles = e.Data.GetData(System.Windows.DataFormats.FileDrop) as string[];
			if (null != dropFiles)
			{
				this.inputFilePath.Text = dropFiles[0];
			}
		}

		private void InputFilePath_PreviewDragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop, true))
			{
				e.Effects = System.Windows.DragDropEffects.Copy;
			}
			else
			{
				e.Effects = System.Windows.DragDropEffects.None;
			}
			e.Handled = true;
		}

		/// <summary>
		/// Show message to notify the convertion has finished successfully.
		/// </summary>
		/// <param name="sender">Object this event has sent.</param>
		/// <param name="e">Event argumetn.</param>
		private void OnNotifyOk(object sender, EventArgs e)
		{
			MessageBox.Show("変換しました。", "XML変換", MessageBoxButton.OK);
		}

		/// <summary>
		/// Show message to notify the convertoin has failed.
		/// </summary>
		/// <param name="sender">Object this event has sent.</param>
		/// <param name="e">Event argument</param>
		private void OnNotifyNg(object sender, EventArgs e)
		{
			MessageBox.Show("変換できませんでした。", "XML変換", MessageBoxButton.OK, MessageBoxImage.Exclamation);
		}

		/// <summary>
		/// Event handler to handle the data context changing.
		/// </summary>
		/// <param name="sender">Object sender.</param>
		/// <param name="e">Event arguments.</param>
		private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var newViewModel = (CommonViewModelBase)e.NewValue;
			newViewModel.CommandOkEventHandler += this.OnNotifyOk;
			newViewModel.CommandNgEventHandler += this.OnNotifyNg;
		}
	}
}
