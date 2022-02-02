using System;
using System.Collections.Generic;
using System.Text;

namespace CountrySideEngineer.ProgressWindow.Model.Interface
{
	public interface IAsyncTask<T>
	{
		void RunTask(IProgress<T> progress);
	}
}
