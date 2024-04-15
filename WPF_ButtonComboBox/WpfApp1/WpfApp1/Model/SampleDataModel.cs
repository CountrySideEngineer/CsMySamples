using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1.Model 
{
	internal class SampleDataModel 
	{
		public string DataTitle { get; set; }

		public string Content { get; set; }

		public ObservableCollection<string> Commands { get; set; }

		public SampleDataModel()
		{
			DataTitle = string.Empty;
			Content = string.Empty;
			Commands = new ObservableCollection<string>();
		}
	}
}
