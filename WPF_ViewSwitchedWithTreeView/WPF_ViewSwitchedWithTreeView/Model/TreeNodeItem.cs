using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WPF_ViewSwitchedWithTreeView.Model
{
	internal class TreeNodeItem
	{
		public string Name { get; set; } = string.Empty;

		public string Path { get; set; } = string.Empty;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TreeNodeItem() { }
	}
}
