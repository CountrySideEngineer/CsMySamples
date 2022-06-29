using System;
using System.Collections.Generic;
using System.Text;

namespace CSEngineer.Logger.Interface
{
	public interface ILog
	{
		/// <summary>
		/// TRACE level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void TRACE(string message);

		/// <summary>
		/// DEBUG level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void DEBUG(string message);

		/// <summary>
		/// INFO (information) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void INFO(string message);

		/// <summary>
		/// WARN (warning) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void WARN(string message);

		/// <summary>
		/// ERROR level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void ERROR(string message);

		/// <summary>
		/// FALTAL level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void FATAL(string message);
	}
}
