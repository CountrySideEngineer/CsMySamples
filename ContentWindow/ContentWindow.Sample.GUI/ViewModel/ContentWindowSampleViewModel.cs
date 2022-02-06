using ContentWindow.Sample.GUI.Command;
using CountrySideEngineer.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentWindow.Sample.GUI.ViewModel
{
	public class ContentWindowSampleViewModel : ViewModelBase
	{
		/// <summary>
		/// Field of command.
		/// </summary>
		protected DelegateCommand _sampleCommand;

		/// <summary>
		/// Property command to execute sample command.
		/// </summary>
		public DelegateCommand SampleCommand
		{
			get
			{
				if (null == _sampleCommand)
				{
					_sampleCommand = new DelegateCommand(this.SampleCommandExecute);
				}
				return _sampleCommand;
			}
		}

		/// <summary>
		/// Body of sample command to execute.
		/// </summary>
		public void SampleCommandExecute()
		{
			var command = new StartSampleCommand();
			command.Execute();
		}

	}
}
