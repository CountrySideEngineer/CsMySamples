using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxSample.ViewModel
{
	public class ComboBoxViewModel : ViewModelBase
	{
		protected UInt32 _selectedItemIndex1;
		public UInt32 SelectedItemIndex1
		{
			get => _selectedItemIndex1;
			set
			{
				_selectedItemIndex1 = value;
				RaisePropertyChanged(nameof(SelectedItemIndex1));
			}
		}

		protected IEnumerable<string> _comboBoxItems1;
		public IEnumerable<string> ComboBoxItems1
		{
			get => _comboBoxItems1;
			set
			{
				_comboBoxItems1 = value;
				RaisePropertyChanged(nameof(ComboBoxItems1));
			}
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ComboBoxViewModel() : base()
		{
			var comboBoxItems1 = new List<string>()
			{
				"string item 1",
				"string item 2",
				"string item 3",
				"string item 4",
				"string item 5"
			};
			ComboBoxItems1 = comboBoxItems1;
		}
	}
}
