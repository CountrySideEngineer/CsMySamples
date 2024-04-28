using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxSample.Model
{
	public class SampleModelItem
	{
		public string Name { get; set; }

		public string Content { get; set; }

		public SampleModelItem()
		{
			Name = string.Empty;
			Content = string.Empty;
		}
	}
}
