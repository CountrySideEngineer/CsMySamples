using CountrySideEngineer.ContentWindow.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ContentWindow.Sample.GUI.Command
{
	public class StartSampleCommand
	{
		protected delegate void ContentReceivedEvent(object sender, ContentReceivedEventArgs e);
		ContentReceivedEvent ContentReceivedEventHandler;

		public void Execute()
		{
			_contentWindow = new CountrySideEngineer.ContentWindow.ContentWindow("Sample Content");
			this.ContentReceivedEventHandler += _contentWindow.OnContentReceived;
			_contentWindow.Start();

			var timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
			timer.Tick += TimerDispatcher;
			timer.Start();
		}

		CountrySideEngineer.ContentWindow.ContentWindow _contentWindow;
		protected int _dispatchCount = 0;

		protected void TimerDispatcher(object sender, EventArgs e)
		{
			if (_dispatchCount < 200)
			{
				string content = $"Dispatch counte = {_dispatchCount}\r\n";
				var eventArgs = new ContentReceivedEventArgs(content);
				ContentReceivedEventHandler?.Invoke(this, eventArgs);
				_dispatchCount++;
				Debug.Write($"{DateTime.Now} {content}");
			}
			else
			{
				_contentWindow.Finish();
			}
		}
	}
}
