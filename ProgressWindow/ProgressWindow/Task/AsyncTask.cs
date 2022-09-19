using CountrySideEngineer.ProgressWindow.Task.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySideEngineer.ProgressWindow.Task
{
	public class AsyncTask<T> : IAsyncTask<T>
	{
		protected IProgress<T> _progress;

		public delegate void AsyncTaskDelegate(IProgress<T> progress);

		public AsyncTask()
		{
			TaskAction = null;
			_progress = null;
		}

		public void RunTask(IProgress<T> progress)
		{
			try
			{
				if (null == progress)
				{
					throw new NullReferenceException();
				}
				if (null == TaskAction)
				{
					throw new NullReferenceException();
				}
				System.Threading.Tasks.Task task = RunAsync(progress);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		protected virtual async System.Threading.Tasks.Task RunAsync(IProgress<T> progress)
		{
			System.Threading.Tasks.Task task = Run(progress);
			await task;
		}

		protected virtual System.Threading.Tasks.Task Run(IProgress<T> progress)
		{
			_progress = progress;
			System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Run(() =>
			{
				TaskAction?.Invoke(progress);
			});
			return task;
		}

		public Action<IProgress<T>> TaskAction;
	}
}
