using CSEngineer.Logger.EventArg;
using CSEngineer.Logger.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSEngineer.Logger
{
	public abstract class ALog : ILog, ILogEvent
	{
		/// <summary>
		/// TRACE level log tag.
		/// </summary>
		protected static string _TRACE = "TRACE";

		/// <summary>
		/// DEBUG level log tag.
		/// </summary>
		protected static string _DEBUG = "DEBUG";

		/// <summary>
		/// INFO level log tag.
		/// </summary>
		protected static string _INFO = "INFO";

		/// <summary>
		/// WARN level log tag.
		/// </summary>
		protected static string _WARN = "WARN";

		/// <summary>
		/// ERROR level log tag.
		/// </summary>
		protected static string _ERROR = "ERROR";

		/// <summary>
		/// FATAL level log tag.
		/// </summary>
		protected static string _FATAL = "FATAL";

		/// <summary>
		/// DEBUG level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public void DEBUG(object sender, EventArgs e)
		{
			Output(ALog._DEBUG, e);
		}

		public void DEBUG(string message)
		{
			Output(ALog._DEBUG, message);
		}

		/// <summary>
		/// ERROR level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public void ERROR(object sender, EventArgs e)
		{
			Output(ALog._ERROR, e);
		}

		public void ERROR(string message)
		{
			Output(ALog._ERROR, message);
		}

		/// <summary>
		/// FATAL level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public void FATAL(object sender, EventArgs e)
		{
			Output(ALog._FATAL, e);
		}

		public void FATAL(string message)
		{
			Output(ALog._FATAL, message);
		}

		/// <summary>
		/// INFO (information) level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public void INFO(object sender, EventArgs e)
		{
			Output(ALog._FATAL, e);
		}

		public void INFO(string message)
		{
			Output(ALog._INFO, message);
		}

		/// <summary>
		/// TRACE level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public void TRACE(object sende, EventArgs e)
		{
			Output(ALog._TRACE, e);
		}

		public void TRACE(string message)
		{
			Output(ALog._TRACE, message);
		}

		/// <summary>
		/// WARN (warning) level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public void WARN(object sender, EventArgs e)
		{
			Output(ALog._WARN, e);
		}

		public void WARN(string message)
		{
			Output(ALog._WARN, message);
		}

		/// <summary>
		/// Extract log message from event argument.
		/// </summary>
		/// <param name="e">Event argument.</param>
		/// <returns>Log message.</returns>
		protected string ExtractMessage(EventArgs e)
		{
			try
			{
				var logEventArsg = (LogEventArgs)e;
				string message = logEventArsg.Message;

				return message;
			}
			catch (Exception ex)
			when ((ex is InvalidCastException) || (ex is NullReferenceException))
			{
				string message = "Unknown message received.";
				return message;
			}
			catch (Exception)
			{
				string message = "Invalid message received.";
				return message;
			}
		}

		/// <summary>
		/// Output message from event argument.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="e">Event argument.</param>
		protected virtual void Output(string level, EventArgs e)
		{
			string message = ExtractMessage(e);
			Output(level, message);
		}

		/// <summary>
		/// Abstract method to output log message.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="message">Log message.</param>
		public abstract void Output(string level, string message);
	}
}
