using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountrySideEngineer.ProgressWindow.Task.Interface;

namespace ProgressWindow.Sample.GUI.Command
{
	public class ExecuteAsyncCommand
	{
		public void Execute()
		{
			var task = new HeavyTask();
			var progWindow = new CountrySideEngineer.ProgressWindow.ProgressWindow();
			progWindow.Start(task);

			return;
		}
	}
}
