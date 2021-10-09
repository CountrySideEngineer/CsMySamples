using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginSdk
{
    public interface IPlugin
    {
        /// <summary>
        /// プラグイン機能のI/F
        /// </summary>
        /// <param name="message">プラグインに提示するメッセージ</param>
        PluginOutput PluginFunction(string message);
    }
}
