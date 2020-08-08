using System;
using System.IO;
using System.Text;
using CSEng;

namespace LoggerSample
{
	/// <summary>
	/// Sample program using Logger.dll
	/// </summary>
	public class Program
	{
		static void Main(string[] args)
		{
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
			}
			return;
		}
	}
}
