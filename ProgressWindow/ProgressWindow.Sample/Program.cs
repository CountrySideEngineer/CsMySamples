using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressWindow.Sample
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			var task = new HeavyTask();
			var progressView = new CountrySideEngineer.ProgressWindow.ProgressWindow();
			progressView.Start(task);

			return;
		}
	}
}
