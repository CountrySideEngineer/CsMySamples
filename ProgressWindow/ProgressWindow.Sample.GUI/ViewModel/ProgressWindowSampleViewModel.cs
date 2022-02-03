using CSEngineer.ViewModel.Base;
using ProgressWindow.Sample.GUI.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressWindow.Sample.GUI.ViewModel
{
	public class ProgressWindowSampleViewModel : ViewModelBase
	{
		protected DelegateCommand _executeAsyncCommand;
		public DelegateCommand ExecuteAsyncCommand
		{
			get
			{
				if (null == _executeAsyncCommand)
				{
					_executeAsyncCommand = new DelegateCommand(this.ExecuteAsyncCommandExecute);
				}
				return _executeAsyncCommand;
			}
		}

		public void ExecuteAsyncCommandExecute()
		{
			var command = new ExecuteAsyncCommand();
			command.Execute();
		}
	}
}
