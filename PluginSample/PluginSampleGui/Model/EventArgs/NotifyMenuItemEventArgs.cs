using PluginSample;
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
		public IEnumerable<Plugin> Plugins { get; }

		/// <summary>
		/// Default constructor
		/// </summary>
		protected NotifyMenuItemEventArgs()
		{
			this.Plugins = new List<Plugin>();
		}

		/// <summary>
		/// Constructor with argument,
		/// </summary>
		/// <param name="menuItems">Collection of string to show in menu items.</param>
		public NotifyMenuItemEventArgs(IEnumerable<Plugin> plugins)
		{
			this.Plugins = plugins;
		}
	}
}
