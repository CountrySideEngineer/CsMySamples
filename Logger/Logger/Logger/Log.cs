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
		public void TRACE(string message)
		{
			LogEvent(TraceLogEventHandler, message);
		}

		/// <summary>
		/// DEBUG level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void DEBUG(string message)
		{
			LogEvent(DebugLogEventHandler, message);
		}

		/// <summary>
		/// INFO (information) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void INFO(string message)
		{
			LogEvent(InfoLogEventHandler, message);
		}

		/// <summary>
		/// WARN (warning) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void WARN(string message)
		{
			LogEvent(WarnLogEventHandler, message);
		}

		/// <summary>
		/// ERROR level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void ERROR(string message)
		{
			LogEvent(ErrorLogEventHandler, message);
		}

		/// <summary>
		/// FATAL level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void FATAL(string message)
		{
			LogEvent(FatalLogEventHandler, message);
		}

		/// <summary>
		/// Raise log send event.
		/// </summary>
		/// <param name="eventHandler">Log event handler (delegate).</param>
		/// <param name="message">Log message</param>
		protected void LogEvent(LogEventHandler eventHandler, string message)
		{
			var eventArg = new LogEventArgs(message);
			eventHandler?.Invoke(this, eventArg);
		}
	}
}
