using PluginSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginB
{
	public class PluginB : IPlugin
	{
		public PluginOutput PluginFunction(string message)
		{
			var output = new PluginOutput();
			output.message = $"This is {nameof(PluginB)}\r\n";
			output.message += message;

			return output;
		}
	}
}
