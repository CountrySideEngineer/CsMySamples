using CSEng.ViewModel;
using CStubMKGui.Command;
using DynamicMenuItem.Model;
using PluginSample;
using PluginSampleGui.Model.EventArgs;
using PluginSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PluginSampleGui.ViewModel
{
	public class PluginSampleGuiViewModel : ViewModelBase
	{
		/// <summary>
		/// Delegate event handler to notify plugins view model object loaded.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="args">Event args.</param>
		public delegate void NotifyPluginItemEventHandler(object sender, EventArgs args);

		/// <summary>
		/// Event to notify plugin items.
		/// </summary>
		public event NotifyPluginItemEventHandler RaiseNotifyPluginItemEvent;

		/// <summary>
		/// Delegate event handler to pass message.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		public delegate void NotifyMessageEventHandler(object sender, EventArgs args);

		/// <summary>
		/// Event handler to pass message.
		/// </summary>
		public event NotifyMessageEventHandler NotifyMessageEvent;

		/// <summary>
		/// Notify plugin menu.
		/// </summary>
		/// <param name="plugins">Collection of plugins</param>
		public void NotifyPluginItem(IEnumerable<Plugin> plugins)
		{
			var eventArgs = new NotifyMenuItemEventArgs(plugins);
			this.RaiseNotifyPluginItemEvent?.Invoke(this, eventArgs);
		}

		/// <summary>
		/// Load plugin infos
		/// </summary>
		public void LoadPlugins()
		{
			PluginManager pluginManager = new PluginManager();
			Plugin[] plugins = pluginManager.GetPluginInfos();
			IEnumerable<Plugin> pluginCollection = plugins.ToList();

			this.NotifyPluginItem(pluginCollection);
		}

		/// <summary>
		/// Event handler about loading the view model as data context.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="args">Event args.</param>
		public void ViewModelLoadedEventHandler(object sender, EventArgs args)
		{
			this.LoadPlugins();
		}

		/// <summary>
		/// DelegateCommand object to execute command in menu bar selected.
		/// </summary>
		protected DelegateCommand<int> _MenuExecuteCommand;

		/// <summary>
		/// Delegate command property.
		/// </summary>
		public DelegateCommand<int> MenuExecuteCommand
		{
			get
			{
				if (null == _MenuExecuteCommand)
				{
					this._MenuExecuteCommand = new DelegateCommand<int>(
						this.MenuExecuteCommandExecute, 
						this.CanMenuExecuteCommandExecute);
				}
				return this._MenuExecuteCommand;
			}
		}

		/// <summary>
		/// Body of command to execute menu command.
		/// </summary>
		/// <param name="index">Selected item index in menu bar.</param>
		public void MenuExecuteCommandExecute(int id)
		{
			PluginManager pluginManager = new PluginManager();
			IPlugin plugin = pluginManager.Load(id);
			PluginOutput output = plugin.PluginFunction("message");

			EventArgs eventArgs = new NotifyMessageEventArgs(output.message);
			this.NotifyMessageEvent?.Invoke(this, eventArgs);
		}

		/// <summary>
		/// Returns whether the command in menu bar selected can be execute or not.
		/// </summary>
		/// <param name="data">Parameter used to judge.</param>
		/// <returns>Returns always true.</returns>
		public Boolean CanMenuExecuteCommandExecute(object data)
		{
			return true;
		}
	}
}
