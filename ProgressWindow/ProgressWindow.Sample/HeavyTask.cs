using CountrySideEngineer.ProgressWindow.Model;
using CountrySideEngineer.ProgressWindow.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressWindow.Sample
{
	public class HeavyTask : IAsyncTask<ProgressInfo>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public HeavyTask() { }

		/// <summary>
		/// Run task.
		/// </summary>
		/// <param name="progress">Object to handle progress of task.</param>
		public void RunTask(IProgress<ProgressInfo> progress)
		{
			Task task = this.Run(progress);
		}

		/// <summary>
		/// Run task async.
		/// </summary>
		/// <param name="progress">Object to handle progress of task.</param>
		/// <returns>Task running asynchronously.</returns>
		protected virtual async Task Run(IProgress<ProgressInfo> progress)
		{
			Task task = this.CreateTask(progress);
			await task;
		}

		/// <summary>
		/// Create task to run.
		/// </summary>
		/// <param name="progress">Object to handle progress of task.</param>
		/// <returns>Task running asynchronously.</returns>
		protected virtual Task CreateTask(IProgress<ProgressInfo> progress)
		{
			Task task = Task.Run(() =>
			{
				Console.WriteLine($"Start!");

				int denominator = 100;
				var baseProgInfo = new ProgressInfo()
				{
					Title = "ProgressSample",
					Denominator = denominator
				};
				for (int index = 0; index <= denominator; index++)
				{
					Console.WriteLine($"Progress = {index}");
					var progInfo = new ProgressInfo(baseProgInfo);
					progInfo.ProcessName = $"Process_{index}";
					progInfo.Progress = index * 100 / denominator;
					progInfo.Numerator = index;
					progress.Report(progInfo);

					Thread.Sleep(50);
				}
			});
			return task;
		}
	}
}
