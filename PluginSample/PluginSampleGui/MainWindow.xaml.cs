using DynamicMenuItem.Model;
using PluginSample;
using PluginSampleGui.Model.EventArgs;
using PluginSampleGui.ViewModel;
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

namespace PluginSampleGui
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public delegate void LoadMenuItemRequestEventhandler(object sender, EventArgs args);
		public event LoadMenuItemRequestEventhandler LoadMenuItemRequestEvent;

		/// <summary>
		/// Event handler about message to show message.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="args">Event argument.</param>
		public void ShowInfoMessage(object sender, EventArgs args)
		{
			string message = "Default message";
			if (args is NotifyMessageEventArgs)
			{
				var eventArgs = args as NotifyMessageEventArgs;
				message = eventArgs.Message;
			}
			MessageBox.Show(this, message, "Message from plugins.", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Event handler for context changed event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event argument.</param>
		private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var viewModel = (PluginSampleGuiViewModel)e.NewValue;
			viewModel.RaiseNotifyPluginItemEvent += this.NotifyPluginItemEventHandler;
			viewModel.NotifyMessageEvent += this.ShowInfoMessage;

			this.LoadMenuItemRequestEvent += viewModel.ViewModelLoadedEventHandler;

		}

		/// <summary>
		/// Event handler for notifying plugin items.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="args">Event argument including plugin informations.</param>
		public void NotifyPluginItemEventHandler(object sender, EventArgs args)
		{
			var eventArgs = (NotifyMenuItemEventArgs)args;
			var menuItemTitles = eventArgs.Plugins;
			this.LoadMenuItem(menuItemTitles);
		}

		/// <summary>
		/// Load menu item.
		/// </summary>
		/// <param name="plugins">Collection of menu item data.</param>
		private void LoadMenuItem(IEnumerable<Plugin> plugins)
		{
			MenuItem rootMenuItem = (MenuItem)this.FindName("PluginRoot");
			rootMenuItem.Items.Clear();
			foreach (var pluginItem in plugins)
			{
				var menuItem = new MenuItem()
				{
					Header = pluginItem.Title,
					Command = ((PluginSampleGuiViewModel)this.DataContext).MenuExecuteCommand,
					CommandParameter = pluginItem.Id
				};
				rootMenuItem.Items.Add(menuItem);
			}
		}

		/// <summary>
		/// Event handler when window is loaded.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event argument.</param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			this.LoadMenuItemRequestEvent?.Invoke(this, null);
		}
	}
}
