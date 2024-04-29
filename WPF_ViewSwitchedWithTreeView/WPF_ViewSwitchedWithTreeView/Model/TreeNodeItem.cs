using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ViewSwitchedWithTreeView.Model
{
	internal class TreeNodeItem
	{
		public string Name { get; set; }

		public object ViewModel { get; set; }

		public TreeNodeItem()
		{
			Name = string.Empty;
			ViewModel = null;
		}
	}
}
