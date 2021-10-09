using PluginSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginA
{
	public class PluginA : IPlugin
	{
		public PluginOutput PluginFunction(string message)
		{
			var output = new PluginOutput();
			output.message = $"This is {nameof(PluginA)}\r\n";
			output.message += message;

			return output;
		}
	}
}
