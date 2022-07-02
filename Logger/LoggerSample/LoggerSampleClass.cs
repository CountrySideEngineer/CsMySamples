using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerSample
{
	public class LoggerSampleClass : CommonBaseObject
	{
		public LoggerSampleClass() { }

		public void Sample()
		{
			base.TRACE("Sample TRACE message");
			base.DEBUG("Sample DEBUG message");
			base.INFO("Sample INFO message");
			base.WARN("Sample WARN message");
			base.ERROR("Sample ERROR message");
			base.FATAL("Sample FATAL message");
		}
	}
}
