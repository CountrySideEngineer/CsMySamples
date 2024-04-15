using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.Model 
{
	internal class SampleDataModel 
	{
		public string Title { get; set; }

		public string Content { get; set; }

		public ObservableCollection<string> Items { get; set; }

		public ObservableCollection<SampleDataItemModel> Items2 { get; set; }

		public string Item { get; set; }

		public SampleDataModel()
		{
			Title = string.Empty;
			Content = string.Empty;
			Items = new ObservableCollection<string>();
			Item = string.Empty;
			Items2 = new ObservableCollection<SampleDataItemModel>()
			{
				new SampleDataItemModel()
				{
					Summary = "Summary_001",
					Detail = "Detail_001"
				}
			};
		}
	}
}
