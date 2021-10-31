using DynamicMenuItem.Model;
using DynamicMenuItem.ViewModel;
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

namespace DynamicMenuItem
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

		/// <summary>
		/// Data context changed event handler
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event args.</param>
		private void MainWindows_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			DynamicMenuItemViewModel menuItemViewModel = (DynamicMenuItemViewModel)e.NewValue;
			menuItemViewModel.RaiseNotifyMenuItemEvent += this.NotifyMenuItemEventHandler;
			menuItemViewModel.RaiseNotifyMenuItemClearEvent += this.NotifyMenuItemClearEventHandler;

			this.RaiseLoadMenuItemRequestEvent += menuItemViewModel.LoadDynamicMenuRequestEventHandler;
			this.RaiseUnloadMenuItemRequestEvent += menuItemViewModel.UnloadDynamicMenuItemRequestEventHandler;
		}

		/// <summary>
		/// Menu item load request event handler
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="args">Event args.</param>
		public void NotifyMenuItemClearEventHandler(object sender, EventArgs args)
		{
			this.UnloadMenuItem();
		}

		/// <summary>
		/// Menu item unload event handler.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="args">Event args.</param>
		public void NotifyMenuItemEventHandler(object sender, EventArgs args)
		{
			NotifyMenuItemEventArgs eventArgs = (NotifyMenuItemEventArgs)args;
			IEnumerable<string> menuItemTitles = eventArgs.MenuItems;
			this.LoadMenuItem(menuItemTitles);
		}

		/// <summary>
		/// Unload menu items.
		/// </summary>
		protected void UnloadMenuItem()
		{
			MenuItem rootMenuItem = (MenuItem)this.FindName("MenuRoot");
			rootMenuItem.Items.Clear();
		}

		/// <summary>
		/// Load menu item.
		/// </summary>
		/// <param name="menuItemTitles">Collection of menu item title.</param>
		protected void LoadMenuItem(IEnumerable<string> menuItemTitles)
		{
			this.UnloadMenuItem();

			MenuItem rootMenuItem = (MenuItem)this.FindName("MenuRoot");
			foreach (var menuItemTitle in menuItemTitles)
			{
				var menuItem = new MenuItem()
				{
					Header = menuItemTitle
				};
				rootMenuItem.Items.Add(menuItem);
			}
		}

		public delegate void LoadMenuItemRequestEventHandler(object sender, EventArgs args);
		public event LoadMenuItemRequestEventHandler RaiseLoadMenuItemRequestEvent;
		public event LoadMenuItemRequestEventHandler RaiseUnloadMenuItemRequestEvent;

		/// <summary>
		/// Load button click event handler.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event args</param>
		private void LoadButton_Click(object sender, RoutedEventArgs e)
		{
			this.RaiseLoadMenuItemRequestEvent?.Invoke(this, new EventArgs());

		}

		/// <summary>
		/// Unload button clicl event handler.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event args.</param>
		private void UnloadButton_Click(object sender, RoutedEventArgs e)
		{
			this.RaiseUnloadMenuItemRequestEvent(this, new EventArgs());
		}
	}
}
