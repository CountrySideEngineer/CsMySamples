using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using CSEngineer;
using CSEngineer.Logger;
using CSEngineer.Logger.Interface;

namespace LoggerSample
{
	/// <summary>
	/// Sample program using Logger.dll
	/// </summary>
	public class Program
	{
		static void SetupLogger(ref ILogEvent logEvent)
		{
			var logger = Log.GetInstance();
			logger.TraceLogEventHandler += logEvent.TRACE;
			logger.DebugLogEventHandler += logEvent.DEBUG;
			logger.InfoLogEventHandler += logEvent.INFO;
			logger.WarnLogEventHandler += logEvent.WARN;
			logger.ErrorLogEventHandler += logEvent.ERROR;
			logger.FatalLogEventHandler += logEvent.FATAL;
		}

		static void Main(string[] args)
		{
			ILogEvent consoleLog = new CSEngineer.Logger.Console.Log();
			ILogEvent fileLog = new CSEngineer.Logger.File.Log();


			//SetupLogger(ref consoleLog);
			SetupLogger(ref fileLog);

			var logger = Log.GetInstance();
			logger.TRACE("Sample TRACE message");
			logger = Log.GetInstance();
			logger.DEBUG("Sample DEBUG message");
			logger = Log.GetInstance();
			logger.INFO("Sample INFO message");
			logger = Log.GetInstance();
			logger.WARN("Sample WARN message");
			logger = Log.GetInstance();
			logger.ERROR("Sample ERROR message");
			logger = Log.GetInstance();
			logger.FATAL("Sample FATAL message");

			return;
		}

	}
}
