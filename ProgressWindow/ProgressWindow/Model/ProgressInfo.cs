using System;
using System.Collections.Generic;
using System.Text;

namespace CountrySideEngineer.ProgressWindow.Model
{
	public class ProgressInfo
	{
		/// <summary>
		/// Process title.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Process name.
		/// </summary>
		public string ProcessName { get; set; }

		/// <summary>
		/// Progress.
		/// </summary>
		public int Progress { get; set; }

		/// <summary>
		/// Numerator of progress.
		/// </summary>
		public int Numerator { get; set; }

		/// <summary>
		/// Denominator of progress.
		/// </summary>
		public int Denominator { get; set; }

		/// <summary>
		/// The process should continue or not.
		/// </summary>
		public bool ShouldContinue { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ProgressInfo()
		{
			Title = string.Empty;
			ProcessName = string.Empty;
			Progress = 0;
			Numerator = 0;
			Denominator = 0;
			ShouldContinue = true;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="src">Source to be copied.</param>
		public ProgressInfo(ProgressInfo src)
		{
			try
			{
				Title = src.Title;
				ProcessName = src.ProcessName;
				Progress = src.Progress;
				Numerator = src.Numerator;
				Denominator = src.Denominator;
				ShouldContinue = src.ShouldContinue;
			}
			catch (NullReferenceException)
			{
				/*
				 * Ignore the exception.
				 */
			}
		}
	}
}
