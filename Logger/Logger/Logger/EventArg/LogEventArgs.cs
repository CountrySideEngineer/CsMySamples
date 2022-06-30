using System;
using System.Collections.Generic;
using System.Text;

namespace CSEngineer.Logger.EventArg
{
	/// <summary>
	/// Event argument class for log event.
	/// </summary>
	public class LogEventArgs : EventArgs
	{
		/// <summary>
		/// Event message.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LogEventArgs() : base()
		{
			Message = string.Empty;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="message">Event message.</param>
		public LogEventArgs(string message) : base()
		{
			Message = message;
		}
	}
}
