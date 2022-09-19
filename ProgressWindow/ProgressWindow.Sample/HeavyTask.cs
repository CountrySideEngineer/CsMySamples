using CountrySideEngineer.ProgressWindow.Model;
using CountrySideEngineer.ProgressWindow.Task.Interface;
using System;
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

				ProgressInfo info = new ProgressInfo();

				int denominator = 100;
				var baseProgInfo = new ProgressInfo()
				{
					Title = "ProgressSample",
					Denominator = denominator
				};
				for (int index = 0; index < 10; index++)
				{
					for (int index2 = 0; index2 <= denominator; index2++)
					{
						ProgressInfo progInfo = new ProgressInfo(baseProgInfo);
						progInfo.ProcessName = $"Process_{index2} ({index} / 10)";
						progInfo.Progress = index2 * 100 / denominator;
						progInfo.Numerator = index2;
						progInfo.ShouldContinue = true;
						progress.Report(progInfo);

						Thread.Sleep(5);
					}
				}

				var endInfo = new ProgressInfo(baseProgInfo);
				endInfo.ShouldContinue = false;
				progress.Report(endInfo);

			});
			return task;
		}
	}
}
