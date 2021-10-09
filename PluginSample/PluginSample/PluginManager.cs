using PluginSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluginSample
{
	public class PluginManager
	{
		public IPlugin[] Load()
		{
			//カレントディレクトリにあるディレクトリを取得
			string currentDir = 
				System.IO.Path.GetDirectoryName(
					System.Reflection.Assembly.GetExecutingAssembly().Location);
			string[] dllFiles = System.IO.Directory.GetFiles(currentDir, "*.dll");

			var arrayList = new System.Collections.ArrayList();
			var types = new List<Type>();
			foreach (var dllFile in dllFiles)
			{
				Assembly assembly = Assembly.LoadFrom(dllFile);
				var ifTypes = assembly.GetTypes()
								.Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && (t.GetInterface(nameof(IPlugin)) != null))
								.ToList();
				types.AddRange(ifTypes);
			}
			var plugins = new List<IPlugin>();
			types.ForEach(typeItem =>
			{
				var plugin = (IPlugin)Activator.CreateInstance(typeItem);
				plugins.Add(plugin);
			});
			return plugins.ToArray();
		}
	}
}
