using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
	internal class CustomDataGridViewModel : ViewModelBase
	{
		public ObservableCollection<SampleDataModel> SampleDataCollection { get; set; }

		public CustomDataGridViewModel() : base()
		{
			SampleDataCollection = new ObservableCollection<SampleDataModel>();
			SampleDataCollection.Add(
				new SampleDataModel()
				{
					DataTitle = "Title_001",
					Content = "Content_001",
					Commands = new ObservableCollection<string>()
					{
						"Command_001_001",
						"Command_001_002",
					}
				});
			SampleDataCollection.Add(
				new SampleDataModel()
				{
					DataTitle = "Title_002",
					Content = "Content_002",
					Commands = new ObservableCollection<string>()
					{
						"Command_002_001",
						"Command_002_002",
						"Command_002_003",
						"Command_002_004",
					}
				});
			SampleDataCollection.Add(
				new SampleDataModel()
				{
					DataTitle = "Title_003",
					Content = "Content_003",
					Commands = new ObservableCollection<string>()
					{
						"Command_003_001",
					}
				});
		}
	}
}
