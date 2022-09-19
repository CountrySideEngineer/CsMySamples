using System;
using System.Collections.Generic;
using System.Text;

namespace CountrySideEngineer.ProgressWindow.Task.Interface
{
	public interface IAsyncTask<T>
	{
		void RunTask(IProgress<T> progress);
	}
}
