﻿using CountrySideEngineer.ProgressWindow.ViewModel;
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

namespace CountrySideEngineer.ProgressWindow.View
{
	/// <summary>
	/// ProgressWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class ProgressWindow : Window
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
		public ProgressWindow()
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
			var viewModel = (ProgressWindowsViewModel)e.NewValue;
			viewModel.CloseWindowEvent += this.OnWindowClose;
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
		private void OnCloseDispatch(object sender, EventArgs e)
		{
			try
			{
				var progressWindow = sender as ProgressWindow;
				progressWindow.Close();
			}
			catch (NullReferenceException)
			{
				this.Close();
			}
		}

		/// <summary>
		/// Window ContentRendered event handler.
		/// When the event raised, 
		/// </summary>
		/// <param name="sender">Event sender</param>
		/// <param name="e">Event argument.</param>
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			try
			{
				var viewModel = (ProgressWindowsViewModel)this.DataContext;
				viewModel.OnProgressStart(this, e);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
