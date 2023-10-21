using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressWindows_WinForm
{
	internal class WorkState
	{
		public int ProgressPercentage { get; set; } = 0;
		public int StageIndex { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
	}
}
