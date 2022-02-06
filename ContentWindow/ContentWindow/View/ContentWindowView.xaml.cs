using CountrySideEngineer.ContentWindow.ViewModel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CountrySideEngineer.ContentWindow.View
{
	/// <summary>
	/// ProgressWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class ContentWindowView : Window
	{
		[DllImport("user32.dll")]
		private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll")]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		const int GWL_STYLE = -16;
		const int WS_SYS_MENU = 0x00080000;

		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e);

			IntPtr handle = new WindowInteropHelper(this).Handle;
			int style = GetWindowLong(handle, GWL_STYLE);
			style = style & (~WS_SYS_MENU);
			SetWindowLong(handle, GWL_STYLE, style);
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ContentWindowView()
		{
			InitializeComponent();
		}

		/// <summary>
		/// DataContextChanged event handler
		/// </summary>
		/// <param name="sender">Event sender</param>
		/// <param name="e">Event argument.</param>
		private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var viewModel = (ContentWindowViewModel)e.NewValue;
			viewModel.StartContentReceiveEvent += this.OnWindowShow;
			viewModel.FinishContentReceiveEvent += this.OnWindowClose;
		}

		private void OnWindowShow(object sender, EventArgs e)
		{
			this.Dispatcher.Invoke(new System.EventHandler(OnShowDispatch), this, null);
		}

		public void OnShowDispatch(object sender, EventArgs e)
		{
			try
			{
				var view = sender as ContentWindowView;
				view.Show();
			}
			catch (NullReferenceException)
			{
				this.Show();
			}
		}

		/// <summary>
		/// WindowClose event handler.
		/// Close this window.
		/// </summary>
		/// <param name="sender">Event sender</param>
		/// <param name="e">Event argument.</param>
		private void OnWindowClose(object sender, EventArgs e)
		{
			//Add delegate to thread queue manager, called "dispatch".
			this.Dispatcher.Invoke(new System.EventHandler(this.OnCloseDispatch), this, null);
		}

		/// <summary>
		/// Close event handler dispatched from dispatcher.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event argument.</param>
		public void OnCloseDispatch(object sender, EventArgs e)
		{
			try
			{
				var view = sender as ContentWindowView;
				view.Close();
			}
			catch (NullReferenceException)
			{
				this.Close();
			}
		}
	}
}
