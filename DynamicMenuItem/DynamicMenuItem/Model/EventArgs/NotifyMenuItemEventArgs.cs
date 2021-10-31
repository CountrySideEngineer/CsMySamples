using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenuItem.Model
{
	public class NotifyMenuItemEventArgs : EventArgs
	{
		/// <summary>
		/// Name of menu items.
		/// </summary>
		public IEnumerable<string> MenuItems { get; }

		/// <summary>
		/// Default constructor
		/// </summary>
		protected NotifyMenuItemEventArgs()
		{
			this.MenuItems = new List<string>();
		}

		/// <summary>
		/// Constructor with argument,
		/// </summary>
		/// <param name="menuItems">Collection of string to show in menu items.</param>
		public NotifyMenuItemEventArgs(IEnumerable<string> menuItems)
		{
			this.MenuItems = new List<string>(menuItems.ToList());
		}
	}
}
