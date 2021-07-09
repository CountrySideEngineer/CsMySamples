using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using CSEngineer;

namespace LoggerSample
{
	/// <summary>
	/// Sample program using Logger.dll
	/// </summary>
	public class Program
	{
		static void Main(string[] args)
		{
			IEnumerable<string> logLevels = Logger.AvailableLogLevelList;
			int index = 0;
			foreach (var logLevel in logLevels)
			{
				Console.WriteLine($"{index} : {logLevel}");
				index++;
			}

			using (var logStream = new StreamWriter(@"./log.txt", false, Encoding.UTF8))
			{
				Logger.AddStream(logStream);
				Logger.Level = Logger.LogLevel.All;
				Logger.TRACE("This is TRACE level message");
				Logger.DEBUG("This is DEBUG level message");
				Logger.INFO("This is INFO level message");
				Logger.WARN("This is WARN level message");
				Logger.ERROR("This is ERROR level message");
				Logger.FATAL("This is FATAL level message");

				Logger.Level = Logger.LogLevel.TRACE;
				Logger.TRACE("This is TRACE level message");
				Logger.DEBUG("This is DEBUG level message");
				Logger.INFO("This is INFO level message");
				Logger.WARN("This is WARN level message");
				Logger.ERROR("This is ERROR level message");
				Logger.FATAL("This is FATAL level message");

				Logger.Level = Logger.LogLevel.DEBUG;
				Logger.TRACE("This is TRACE level message");
				Logger.DEBUG("This is DEBUG level message");
				Logger.INFO("This is INFO level message");
				Logger.WARN("This is WARN level message");
				Logger.ERROR("This is ERROR level message");
				Logger.FATAL("This is FATAL level message");

				Logger.Level = Logger.LogLevel.INFO;
				Logger.TRACE("This is TRACE level message");
				Logger.DEBUG("This is DEBUG level message");
				Logger.INFO("This is INFO level message");
				Logger.WARN("This is WARN level message");
				Logger.ERROR("This is ERROR level message");
				Logger.FATAL("This is FATAL level message");

				Logger.Level = Logger.LogLevel.WARN;
				Logger.TRACE("This is TRACE level message");
				Logger.DEBUG("This is DEBUG level message");
				Logger.INFO("This is INFO level message");
				Logger.WARN("This is WARN level message");
				Logger.ERROR("This is ERROR level message");
				Logger.FATAL("This is FATAL level message");

				Logger.Level = Logger.LogLevel.ERROR;
				Logger.TRACE("This is TRACE level message");
				Logger.DEBUG("This is DEBUG level message");
				Logger.INFO("This is INFO level message");
				Logger.WARN("This is WARN level message");
				Logger.ERROR("This is ERROR level message");
				Logger.FATAL("This is FATAL level message");

				Logger.Level = Logger.LogLevel.FATAL;
				Logger.TRACE("This is TRACE level message");
				Logger.DEBUG("This is DEBUG level message");
				Logger.INFO("This is INFO level message");
				Logger.WARN("This is WARN level message");
				Logger.ERROR("This is ERROR level message");
				Logger.FATAL("This is FATAL level message");

				Logger.Level = Logger.LogLevel.NONE;
				Logger.TRACE("This is TRACE level message");
				Logger.DEBUG("This is DEBUG level message");
				Logger.INFO("This is INFO level message");
				Logger.WARN("This is WARN level message");
				Logger.ERROR("This is ERROR level message");
				Logger.FATAL("This is FATAL level message");

				bool removeResult = Logger.RemoveStream(logStream);
				Debug.WriteLine($"Remove result = {removeResult}");
			}

			Logger.TRACE("This is TRACE level message");
			return;
		}
	}
}
