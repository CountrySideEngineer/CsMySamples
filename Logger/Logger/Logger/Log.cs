using System;
using System.Collections.Generic;
using System.Text;
using CSEngineer.Logger.EventArg;

namespace CSEngineer.Logger
{
	public class Log
	{
		/// <summary>
		/// Log singleton object.
		/// </summary>
		private static Log _instance = null;

		/// <summary>
		/// Deleagate event handler to raise log message event.
		/// </summary>
		/// <param name="sender">Object sender.</param>
		/// <param name="e">Log message event.</param>
		public delegate void LogEventHandler(object sender, EventArgs e);

		/// <summary>
		/// TRACE log level event handler.
		/// </summary>
		public event LogEventHandler TraceLogEventHandler;

		/// <summary>
		/// DEBUG log level event handler.
		/// </summary>
		public event LogEventHandler DebugLogEventHandler;

		/// <summary>
		/// INFO log level event handler.
		/// </summary>
		public event LogEventHandler InfoLogEventHandler;

		/// <summary>
		/// WARNING log level event handler.
		/// </summary>
		public event LogEventHandler WarnLogEventHandler;

		/// <summary>
		/// ERROR log level event handler.
		/// </summary>
		public event LogEventHandler ErrorLogEventHandler;

		/// <summary>
		/// FATAL log level event handler.
		/// </summary>
		public event LogEventHandler FatalLogEventHandler;

		/// <summary>
		/// Default constructor.
		/// </summary>
		private Log() { }

		/// <summary>
		/// Static method to get singleton Log object.
		/// </summary>
		/// <returns>Log object.</returns>
		public static Log GetInstance()
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
		public void _TRACE(string message)
		{
			_LogEvent(TraceLogEventHandler, message);
		}

		public static void TRACE(string message)
		{
		}



		/// <summary>
		/// DEBUG level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void _DEBUG(string message)
		{
			_LogEvent(DebugLogEventHandler, message);
		}

		public static void DEBUG(string message)
		{
		}

		/// <summary>
		/// INFO (information) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void _INFO(string message)
		{
			_LogEvent(InfoLogEventHandler, message);
		}

		public static void INFO(string message)
		{

		}

		/// <summary>
		/// WARN (warning) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void _WARN(string message)
		{
			_LogEvent(WarnLogEventHandler, message);
		}

		public static void WARN(string message)
		{

		}

		/// <summary>
		/// ERROR level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void _ERROR(string message)
		{
			_LogEvent(ErrorLogEventHandler, message);
		}

		public static void ERROR(string message)
		{

		}

		/// <summary>
		/// FATAL level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void _FATAL(string message)
		{
			_LogEvent(FatalLogEventHandler, message);
		}

		public static void FATAL(string message)
		{

		}

		/// <summary>
		/// Raise log send event.
		/// </summary>
		/// <param name="eventHandler">Log event handler (delegate).</param>
		/// <param name="message">Log message</param>
		protected void _LogEvent(LogEventHandler eventHandler, string message)
		{
			var eventArg = new LogEventArgs(message);
			eventHandler?.Invoke(this, eventArg);
		}

		protected static void LogEvent(LogEventHandler eventHandler, string message)
		{
			var eventArg = new LogEventArgs(message);
			eventHandler?.Invoke(Log.GetInstance(), eventArg);
		}

		/// <summary>
		/// Setup event handler.
		/// </summary>
		/// <param name="logger"></param>
		public static void AddLogger(ALog logger)
		{
			var log = Log.GetInstance();

			log.TraceLogEventHandler += logger.TRACE;
			log.DebugLogEventHandler += logger.DEBUG;
			log.InfoLogEventHandler += logger.INFO;
			log.WarnLogEventHandler += logger.WARN;
			log.ErrorLogEventHandler += logger.ERROR;
			log.FatalLogEventHandler += logger.FATAL;
		}
	}
}
