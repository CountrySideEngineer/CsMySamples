using CSEng.ViewModel;
using DynamicMenuItem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenuItem.ViewModel
{
	public class DynamicMenuItemViewModel : ViewModelBase
	{
		/// <summary>
		/// Definition of event notifying the menu item loaded.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="args">Event argument.</param>
		public delegate void MenuItemLoadedEventHandler(object sender, EventArgs args);

		/// <summary>
		/// Event to load menu items.
		/// </summary>
		public event MenuItemLoadedEventHandler RaiseNotifyMenuItemEvent;

		/// <summary>
		/// Event to unload menu items.
		/// </summary>
		public event MenuItemLoadedEventHandler RaiseNotifyMenuItemClearEvent;

		/// <summary>
		/// Request to load menu item event handler.
		/// </summary>
		/// <param name="sender">Event sender</param>
		/// <param name="args">Event argument.</param>
		public void LoadDynamicMenuRequestEventHandler(object sender, EventArgs args)
		{
			var menuItems = new List<string>()
			{
				"MenuItem1",
				"MenuItem2",
				"MenuItem3",
				"MenuItem4",
				"MenuItem5"
			};
			var eventArgs = new NotifyMenuItemEventArgs(menuItems);
			this.RaiseNotifyMenuItemEvent?.Invoke(this, eventArgs);
		}

		/// <summary>
		/// Request to unload menu item event handler.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="args">Event argument.</param>
		public void UnloadDynamicMenuItemRequestEventHandler(object sender, EventArgs args)
		{
			this.RaiseNotifyMenuItemClearEvent?.Invoke(this, args);
		}
	}
}
