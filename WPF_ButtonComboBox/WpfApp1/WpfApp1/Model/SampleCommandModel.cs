using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
	public class SampleCommandModel
	{
		public string Title { get; set; } = string.Empty;

		public string Content { get; set; } = string.Empty;

		public Func<string> Command { get; set; } = null;

		public string Execute()
		{
			Content = Command?.Invoke();

			return Content;
		}
	}
}
