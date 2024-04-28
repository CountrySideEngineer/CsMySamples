using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ViewSwitchedWithTreeView.ViewModel
{
	internal class CustomTreeViewModel : ViewModelBase
	{
		protected IEnumerable<string> _treeItems;
		public IEnumerable<string> TreeItems
		{
			get => _treeItems;
			set
			{
				_treeItems = value;
				RaisePropertyChanged();
			}
		}

		public CustomTreeViewModel()
		{
			TreeItems = new List<string>()
			{
				"TreeItem1",
				"TreeItem2",
				"TreeItem3",
				"TreeItem4",
			};
		}
	}
}
