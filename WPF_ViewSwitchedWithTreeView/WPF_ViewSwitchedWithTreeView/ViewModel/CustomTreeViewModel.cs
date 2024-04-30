using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ViewSwitchedWithTreeView.Model;

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

		protected IEnumerable<TreeNodeItem> _treeNodeItems;
		public IEnumerable<TreeNodeItem> TreeNodeItems
		{
			get => _treeNodeItems;
		}

		protected TreeNodeItem _selectednodeItem;
		public TreeNodeItem SelectedNodeItem
		{
			get => _selectednodeItem;
			set
			{
				_selectednodeItem = value;
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

			_treeNodeItems = new List<TreeNodeItem>()
			{
				new TreeNodeItem()
				{
					Name = "TreeItem1",
					Path = "WPF_ViewSwitchedWithTreeView.View.CustomUserViewControl_001"
				},
				new TreeNodeItem()
				{
					Name = "TreeItem2",
					Path = "WPF_ViewSwitchedWithTreeView.View.CustomUserViewControl_002"
				},
				new TreeNodeItem()
				{
					Name = "TreeItem3",
					Path = "WPF_ViewSwitchedWithTreeView.View.CustomUserViewControl_003"
				},
				new TreeNodeItem()
				{
					Name = "TreeItem4",
					Path = "WPF_ViewSwitchedWithTreeView.View.CustomUserViewControl_004"
				}
			};
		}
	}
}
