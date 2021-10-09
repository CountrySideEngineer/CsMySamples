using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginSdk
{
	/// <summary>
	/// プラグインの成果物を格納するクラス
	/// </summary>
	public class PluginOutput
	{
		/// <summary>
		/// プラグインが生成したメッセ０次
		/// </summary>
		public string message { get; set; }

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public PluginOutput()
		{
			this.message = string.Empty;
		}
	}
}
