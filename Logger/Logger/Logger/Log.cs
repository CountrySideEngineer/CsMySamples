using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CSEngineer.Logger.EventArg;

namespace CSEngineer.Logger
{
	public class Log
	{
		/// <summary>
		/// Deleagate event handler to raise log message event.
		/// </summary>
		/// <param name="sender">Object sender.</param>
		/// <param name="e">Log message event.</param>
		public delegate void LogMessageDelegate(object sender, EventArgs e);

		/// <summary>
		/// TRACE log level event handler.
		/// </summary>
		protected event LogMessageDelegate TraceLogDelegate;

		/// <summary>
		/// DEBUG log level event handler.
		/// </summary>
		protected event LogMessageDelegate DebugLogDelegate;

		/// <summary>
		/// INFO log level event handler.
		/// </summary>
		protected event LogMessageDelegate InfoLogDelegate;

		/// <summary>
		/// WARNING log level event handler.
		/// </summary>
		protected event LogMessageDelegate WarnLogDelegate;

		/// <summary>
		/// ERROR log level event handler.
		/// </summary>
		protected event LogMessageDelegate ErrorLogDelegate;

		/// <summary>
		/// FATAL log level event handler.
		/// </summary>
		protected event LogMessageDelegate FatalLogDelegate;

		/// <summary>
		/// Default constructor.
		/// </summary>
		private Log() { }

		/// <summary>
		/// Log singleton object.
		/// </summary>
		private static Log _instance = null;

		/// <summary>
		/// Static method to get singleton Log object.
		/// </summary>
		/// <returns>Log object.</returns>
		protected static Log GetInstance()
		{
			if (null == Log._instance)
			{
				Log._instance = new Log();
			}
			return Log._instance;
		}

		/// <summary>
		/// TRACE level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void TRACE(
			string message, 
			[CallerFilePath] string filePath = "", 
			[CallerLineNumber] int lineNumber = 0, 
			[CallerMemberName] string memberName = ""
			)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.TraceLogDelegate, message);
		}

		/// <summary>
		/// DEBUG level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void DEBUG(string message)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.DebugLogDelegate, message);
		}

		/// <summary>
		/// INFO (information) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void INFO(string message)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.InfoLogDelegate, message);
		}

		/// <summary>
		/// WARN (warning) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void WARN(string message)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.WarnLogDelegate, message);
		}

		/// <summary>
		/// ERROR level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void ERROR(string message)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.ErrorLogDelegate, message);
		}

		/// <summary>
		/// FATAL level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void FATAL(string message)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.FatalLogDelegate, message);
		}

		/// <summary>
		/// Raise log send event.
		/// </summary>
		/// <param name="eventHandler">Log event handler (delegate).</param>
		/// <param name="message">Log message</param>
		protected static void RaiseLogEvent(
			LogMessageDelegate eventHandler, 
			string message,
			string filePath = "",
			int lineNumber = 0,
			string memberName = ""
			)
		{
			var eventArg = new LogEventArgs(message, filePath, lineNumber, memberName);
			eventHandler?.Invoke(Log.GetInstance(), eventArg);
		}

		/// <summary>
		/// Setup event handler.
		/// </summary>
		/// <param name="logger"></param>
		public static void AddLogger(ALog logger)
		{
			var log = Log.GetInstance();

			log.TraceLogDelegate += logger.TRACE;
			log.DebugLogDelegate += logger.DEBUG;
			log.InfoLogDelegate += logger.INFO;
			log.WarnLogDelegate += logger.WARN;
			log.ErrorLogDelegate += logger.ERROR;
			log.FatalLogDelegate += logger.FATAL;
		}
	}
}
