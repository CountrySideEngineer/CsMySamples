using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBindingSample_001.ViewModel
{
	internal class WpfBindingSampleViewModel : ViewModelBase
	{
		protected CustomDataGridViewModel _customViewModel;
		public CustomDataGridViewModel CustomViewModel
		{
			get => _customViewModel;
			set
			{
				_customViewModel = value;
				RaisePropertyChanged();
			}
		}

		public WpfBindingSampleViewModel() :base()
		{
			CustomViewModel = new CustomDataGridViewModel();
		}
	}
}
