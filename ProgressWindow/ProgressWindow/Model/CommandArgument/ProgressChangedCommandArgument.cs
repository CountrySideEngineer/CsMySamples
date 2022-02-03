using System;
using System.Collections.Generic;
using System.Text;

namespace CountrySideEngineer.ProgressWindow.Model.CommandArgument
{
	public class ProgressChangedCommandArgument
	{
		/// <summary>
		/// Progress information to update.
		/// </summary>
		public ProgressInfo ProgressInfo { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ProgressChangedCommandArgument()
		{
			ProgressInfo = new ProgressInfo();
		}
	}
}
