using CountrySideEngineer.ProgressWindow.Model;
using CountrySideEngineer.ProgressWindow.Task;
using CountrySideEngineer.ProgressWindow.Task.Interface;
using System;
using System.Threading;

namespace ProgressWindow.Sample
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			AsyncTask<ProgressInfo> asyncTask = new AsyncTask<ProgressInfo>
			{
				TaskAction = ((progress) =>
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
				})
			};
			try
			{
				var progressView = new CountrySideEngineer.ProgressWindow.ProgressWindow();
				progressView.Start(asyncTask);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			try
			{
				IAsyncTask<ProgressInfo> heavyTask = new HeavyTask();
				var progressView = new CountrySideEngineer.ProgressWindow.ProgressWindow();
				progressView.Start(heavyTask);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return;
		}
	}
}
