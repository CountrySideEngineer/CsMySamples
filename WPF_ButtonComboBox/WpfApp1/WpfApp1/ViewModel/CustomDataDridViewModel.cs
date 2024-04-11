using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
	internal class CustomDataDridViewModel : ViewModelBase
	{
		public ObservableCollection<SampleDataModel> SampleDataCollection { get; set; }

		public CustomDataDridViewModel() : base()
		{
			SampleDataCollection = new ObservableCollection<SampleDataModel>();
			SampleDataCollection.Add(new SampleDataModel()
			{
				Title = "Title_001",
				Content = "Content_001"
			});
			SampleDataCollection.Add(new SampleDataModel()
			{
				Title = "Title_002",
				Content = "Content_002"
			});
			SampleDataCollection.Add(new SampleDataModel()
			{
				Title = "Title_003",
				Content = "Content_003"
			});
		}
	}
}
