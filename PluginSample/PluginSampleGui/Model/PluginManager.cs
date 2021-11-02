using LiteDB;
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

		public IPlugin Load(Plugin plugin)
		{
			string pluginPath = $@"./{plugin.FileName}";
			var assembly = Assembly.LoadFrom(pluginPath);
			var ifType = assembly.GetTypes()
				.Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && (t.GetInterface(nameof(IPlugin)) != null))
				.FirstOrDefault();
			if (null == ifType)
			{
				return null;
			}
			IPlugin pluginInstance = (IPlugin)Activator.CreateInstance(ifType);
			return pluginInstance;
		}

		/// <summary>
		/// Load plugin from data base.
		/// </summary>
		/// <param name="index">Index of plugin </param>
		/// <returns>Plugin object loaded load from plugin DLL file.</returns>
		/// <exception cref="IndexOutOfRangeException">Argument <para>index</para> is out of range.</exception>
		public IPlugin Load(int index)
		{
			try
			{
				IPlugin[] plugins = this.Load();
				IPlugin plugin = plugins[index];
				return plugin;
			}
			catch (IndexOutOfRangeException)
			{
				throw;
			}
		}

		public void RegistSampleData()
		{
			using (var db = new LiteDatabase(@"./../db/PluginDb.db"))
			{
				var col = db.GetCollection<Plugin>("plugindb");
				var pluginA = new Plugin()
				{
					Title = "PluginA",
					FileName = "PluginA.dll"
				};
				col.Insert(pluginA);
				var pluginB = new Plugin()
				{
					Title = "PluginB",
					FileName = "PluginB.dll"
				};
				col.Insert(pluginB);
			}
		}

		public Plugin[] GetPluginInfos()
		{
			using (var db = new LiteDatabase(@"./../db/PluginDb.db"))
			{
				var col = db.GetCollection<Plugin>("plugindb");

				var query = col.Query().ToEnumerable().ToArray();
				return query;
			}
		}
	}
}
