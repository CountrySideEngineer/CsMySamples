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
		/// <summary>
		/// Progress grass which implements IProgress interaface.
		/// </summary>
		protected IProgress<T> _progress;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AsyncTask()
		{
			TaskAction = null;
			_progress = null;
		}

		/// <summary>
		/// Run task.
		/// </summary>
		/// <param name="progress">Progress class.</param>
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

		/// <summary>
		/// Run task asynchronously.
		/// </summary>
		/// <param name="progress">Progress class.</param>
		/// <returns>Task to run.</returns>
		protected virtual async System.Threading.Tasks.Task RunAsync(IProgress<T> progress)
		{
			System.Threading.Tasks.Task task = Run(progress);
			await task;
		}

		/// <summary>
		/// Start running task.
		/// </summary>
		/// <param name="progress">Progress class.</param>
		/// <returns>Task class running.</returns>
		protected virtual System.Threading.Tasks.Task Run(IProgress<T> progress)
		{
			_progress = progress;
			System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Run(() =>
			{
				TaskAction?.Invoke(progress);
			});
			return task;
		}

		/// <summary>
		/// Action object to run asynchronously.
		/// </summary>
		public Action<IProgress<T>> TaskAction;
	}
}
