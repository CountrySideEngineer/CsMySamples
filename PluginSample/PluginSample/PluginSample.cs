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
            PluginManager manager = new PluginManager();
            Plugin[] pluginDatas = manager.GetPluginInfos();

            IPlugin plugin = manager.Load(pluginDatas[0]);
            PluginOutput pluginOutput = plugin.PluginFunction("PLUGIN MANAGE SAMPLE");
            Console.WriteLine(pluginOutput.message);

            plugin = manager.Load(pluginDatas[1]);
            pluginOutput = plugin.PluginFunction("PLUGIN MANAGE SAMPLE");
            Console.WriteLine(pluginOutput.message);

            return;
		}
    }
}
