using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
	internal class SampleDataItemModel
	{
		public string DataTitle { get; set; }

		public string DataContent { get; set; }

		public SampleDataItemModel()
		{
			DataTitle = string.Empty;
			DataContent = string.Empty;	
		}
	}
}
