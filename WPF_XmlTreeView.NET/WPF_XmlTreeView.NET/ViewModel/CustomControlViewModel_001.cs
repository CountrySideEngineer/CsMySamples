using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_XmlTreeView.NET.Command;

namespace WPF_XmlTreeView.NET.ViewModel
{
	internal class CustomControlViewModel_001 : ViewModelBase
	{
		public string TypeName
		{
			get
			{
				return GetType().Name;
			}
		}

		protected DelegateCommand? _customCommand = null;
		public DelegateCommand? CustomCommand
		{
			get
			{
				if (null == _customCommand)
				{

				}
				return _customCommand;
			}
		}

		protected string _content_001 = string.Empty;
		public string Content_001
		{
			get => _content_001;
			set
			{
				_content_001 = value;
				RaisePropertyChanged();
			}
		}

		protected string _content_002 = string.Empty;
		public string Content_002
		{
			get => _content_002;
			set
			{
				_content_002 = value;
				RaisePropertyChanged();
			}
		}

		public virtual void CustomCommandExecute()
		{
			Console.WriteLine($"{nameof(CustomCommandExecute)} called.");
		}



	}
}
