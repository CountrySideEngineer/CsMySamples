using Accessibility;
using ExpanderSample_001.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace ExpanderSample_001.ViewModel
{
	internal class MainWindowViewModel : ViewModelBase
	{
		protected string _windowTitle = string.Empty;
		public string WindowTitle
		{
			get => _windowTitle;
			set
			{
				_windowTitle = value;
				RaisePropertyChanged();
			}
		}

		protected ObservableCollection<object>? _itemCollection;
		public ObservableCollection<object>? ItemCollection
		{
			get => _itemCollection;
			set
			{
				_itemCollection = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MainWindowViewModel() : base()
		{
			ItemCollection = new ObservableCollection<object>()
			{
				new DataItem<int>()
				{
					Title = "Item_001",
					InputData = 0,
					Command = ((input) =>
					{
						return 1;
					})
				},
				new DataItem<string>()
				{
					Title = "Item_002",
					InputData = string.Empty,
					Command = ((input) =>
					{
						return "002";
					})
				},
				new DataItem<bool>()
				{
					Title = "Item_003",
					InputData = false,
					Command = ((input) =>
					{
						return true;
					})
				},
			};
		}
	}
}
