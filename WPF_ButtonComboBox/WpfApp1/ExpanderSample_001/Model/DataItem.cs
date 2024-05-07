using ExpanderSample_001.Command;
using ExpanderSample_001.ViewModel;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Serialization;

namespace ExpanderSample_001.Model
{
	internal class DataItem<T> : ViewModelBase
	{
		public Func<T, T>? Command { get; set; }

		public string Title { get; set; } = string.Empty;

		protected T _inputData;
		public T InputData
		{
			get => _inputData;
			set
			{
				_inputData = value;
				RaisePropertyChanged();
			}
		}

		protected DelegateCommand? _itemCommand = null;
		public DelegateCommand ItemCommand
		{
			get
			{
				if (null == _itemCommand)
				{
					_itemCommand = new DelegateCommand(ItemCommandExecute);
				}
				return _itemCommand;
			}
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DataItem() { }

		/// <summary>
		/// Execute command.
		/// </summary>
		public void ItemCommandExecute()
		{
			T inputData = InputData;

			InputData = Command.Invoke(inputData) ?? inputData;
		}
	}
}
