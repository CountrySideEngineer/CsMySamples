using PluginSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginSample
{
    public class PluginSample
    {
        public static void Main()
		{
            PluginManager load = new PluginManager();
            IPlugin[] plugins = load.Load();
            foreach (var plugin in plugins)
			{
                PluginOutput output = plugin.PluginFunction(plugin.GetType().FullName);
                Console.WriteLine(output.message);
			}

            return;
		}
    }
}
