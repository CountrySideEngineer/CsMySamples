using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySideEngineer.ContentWindow.Model
{
	public class ContentReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// Field of received data.
		/// </summary>
		protected string _data;

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="data">Received data</param>
		public ContentReceivedEventArgs(string data)
		{
			_data = data;
		}

		/// <summary>
		/// Received data property.
		/// </summary>
		public string Data { get => _data; }
	}
}
