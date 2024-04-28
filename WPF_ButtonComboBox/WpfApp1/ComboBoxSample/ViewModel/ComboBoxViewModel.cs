using ComboBoxSample.Command;
using ComboBoxSample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Packaging;
using System.Linq;
using System.Security.Policy;
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

		protected int _sampleDataIndex;
		public int SampleDataIndex
		{
			get => _sampleDataIndex;
			set
			{
				_sampleDataIndex = value;
				RaisePropertyChanged();
			}
		}

		protected ObservableCollection<SampleModelItem> _sampleDataCollection;
		public ObservableCollection<SampleModelItem> SampleDataCollection
		{
			get => _sampleDataCollection;
			set
			{
				_sampleDataCollection = value;
				RaisePropertyChanged();
			}
		}

		protected string _userInputText;
		public string UserInputText
		{
			get => _userInputText;
			set
			{
				if (SampleDataIndex < 0)
				{
				}
				else
				{
					_userInputText = value;
					RaisePropertyChanged();
				}
			}
		}

		public DelegateCommand MySelectionChanged { get; set; }


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

			SampleDataCollection = new ObservableCollection<SampleModelItem>()
			{
				new SampleModelItem()
				{
					Name = "item name 001",
					Content = "Sample model item content 001",
				},
				new SampleModelItem()
				{
					Name = "item name 002",
					Content = "Sample model item content 002",
				},
				new SampleModelItem()
				{
					Name = "item name 003",
					Content = "Sample model item content 003",
				},
			};

			UserInputText = string.Empty;

			MySelectionChanged = new DelegateCommand(() =>
			{
				UserInputText = $"SampleDataIndex = {SampleDataIndex}";
				Debug.WriteLine(UserInputText);
			});
		}


	}
}
