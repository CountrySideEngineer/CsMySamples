using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginSampleGui.Model.EventArgs
{
	public class NotifyMessageEventArgs : System.EventArgs
	{
		public string Message { get; }

		public NotifyMessageEventArgs(string message)
		{
			this.Message = message;
		}
	}
}
