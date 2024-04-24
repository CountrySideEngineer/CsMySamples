using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.ViewModel;

namespace WpfApp1.Model 
{
	internal class SampleDataModel : ViewModelBase
	{
		public string DataTitle { get; set; }

		public string Content { get; set; }

		protected string _selectedCommand;
		public string SelectedCommand
		{
			get => _selectedCommand;
			set
			{
				_selectedCommand = value;
				RaisePropertyChanged();
			}
		}

		protected IEnumerable<string> _commands;
		public IEnumerable<string> Commands
		{
			get => _commands;
			set
			{
				_commands = value;
				RaisePropertyChanged();
			}
		}

		public SampleDataModel()
		{
			DataTitle = string.Empty;
			Content = string.Empty;
			Commands = new List<string>();

			SelectedCommand = string.Empty;
		}
	}
}
