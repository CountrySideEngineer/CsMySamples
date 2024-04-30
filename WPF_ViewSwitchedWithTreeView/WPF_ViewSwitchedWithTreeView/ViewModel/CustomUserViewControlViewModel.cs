using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_ViewSwitchedWithTreeView.ViewModel
{
	internal class CustomUserViewControlViewModel : ViewModelBase
	{
		protected string _userInputText = string.Empty;
		public string UserInputText
		{
			get => _userInputText;
			set
			{
				_userInputText = value;
				RaisePropertyChanged();
			}
		}

		public CustomUserViewControlViewModel() : base()
		{
			UserInputText = string.Empty;
		}
		
	}
}
