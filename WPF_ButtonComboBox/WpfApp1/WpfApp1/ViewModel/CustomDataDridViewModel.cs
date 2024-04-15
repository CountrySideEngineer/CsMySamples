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
			var item1 = new ObservableCollection<SampleDataItemModel>();
			item1.Add(new SampleDataItemModel()
			{
				Summary = "Summary_001_001",
				Detail = "Detail_001_001"
			});
			item1.Add(new SampleDataItemModel()
			{
				Summary = "Summary_001_002",
				Detail = "Detail_001_002"
			});
			item1.Add(new SampleDataItemModel()
			{
				Summary = "Summary_001_003",
				Detail = "Detail_001_003"
			});
			var item2 = new ObservableCollection<SampleDataItemModel>();
			item2.Add(new SampleDataItemModel()
			{
				Summary = "Summary_002_001",
				Detail = "Detail_002_001"
			});
			item2.Add(new SampleDataItemModel()
			{
				Summary = "Summary_002_002",
				Detail = "Detail_002_002"
			});

			var item3 = new ObservableCollection<SampleDataItemModel>();
			item3.Add(new SampleDataItemModel()
			{
				Summary = "Summary_003_001",
				Detail = "Detail_003_001"
			});
			item3.Add(new SampleDataItemModel()
			{
				Summary = "Summary_003_002",
				Detail = "Detail_003_002"
			});
			item3.Add(new SampleDataItemModel()
			{
				Summary = "Summary_003_002",
				Detail = "Detail_003_002"
			});
			item3.Add(new SampleDataItemModel()
			{
				Summary = "Summary_003_002",
				Detail = "Detail_003_002"
			});
			item3.Add(new SampleDataItemModel()
			{
				Summary = "Summary_003_002",
				Detail = "Detail_003_002"
			});





			SampleDataCollection = new ObservableCollection<SampleDataModel>();
			SampleDataCollection.Add(new SampleDataModel()
			{
				Title = "Title_001",
				Content = "Content_001",
				Items = new ObservableCollection<string>()
				{
					"<Item_001_001>",
					"<Item_001_002>",
					"<Item_001_003>",
					"<Item_001_004>",
				},
				Items2 = item1,
			});
			SampleDataCollection.Add(new SampleDataModel()
			{
				Title = "Title_002",
				Content = "Content_002",
				Items = new ObservableCollection<string>()
				{
					"<Item_002_001>",
					"<Item_002_002>",
				},
				Items2 = item2
			});
			SampleDataCollection.Add(new SampleDataModel()
			{
				Title = "Title_003",
				Content = "Content_003",
				Items = new ObservableCollection<string>()
				{
					"<Item_003_001>",
				},
				Item = "Item_003_001_0",
				Items2 = item3
			});
		}
	}
}
