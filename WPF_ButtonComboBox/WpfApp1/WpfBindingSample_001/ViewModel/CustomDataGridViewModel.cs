using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WpfBindingSample_001.Model;

namespace WpfBindingSample_001.ViewModel
{
	internal class CustomDataGridViewModel : ViewModelBase
	{
		protected int _customRowIndex = 0;
		public int SelectedRowIndex
		{
			get => _customRowIndex;
			set
			{
				_customRowIndex = value;
				RaisePropertyChanged();
			}
		}

		protected ObservableCollection<CustomRowData> _customDataCollection;
		public ObservableCollection<CustomRowData> CustomDataCollection
		{
			get => _customDataCollection;
			set
			{
				_customDataCollection = value;
				RaisePropertyChanged();
			}
		}

		public CustomDataGridViewModel() : base()
		{
			CustomDataCollection = new ObservableCollection<CustomRowData>()
			{
				new CustomRowData()
				{
					Column_001 = "Column_001_01",
					Column_002 = "Column_002_01",
					Column_003 = "Column_003_01",
				},
				new CustomRowData()
				{
					Column_001 = "Column_001_02",
					Column_002 = "Column_002_02",
					Column_003 = "Column_003_02",
				},
			};
		}
	}
}
