using System;
using System.Collections.Generic;
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

		public SampleDataModel()
		{
			Title = string.Empty;
			Content = string.Empty;
		}
	}
}
