using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_XmlTreeView.NET.ViewModel
{
	internal class CustomControlViewModel_002 : CustomControlViewModel_001
	{
		protected string _content_003 = string.Empty;
		public string Content_003
		{
			get => _content_003;
			set
			{
				_content_003 = value;
				RaisePropertyChanged();
			}
		}

		public override void CustomCommandExecute()
		{
			base.CustomCommandExecute();

			Console.WriteLine($"{nameof(CustomCommandExecute)} in {nameof(CustomControlViewModel_002)} called.");
		}
	}
}
