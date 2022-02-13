using CountrySideEngineer.ContentWindow.Model;
using CountrySideEngineer.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySideEngineer.ContentWindow.ViewModel
{
	public class ContentWindowViewModel : ViewModelBase
	{
		/// <summary>
		/// Field of property
		/// </summary>
		protected string _title;

		/// <summary>
		/// Field of content
		/// </summary>
		protected string _content;

		/// <summary>
		/// Property of title.
		/// </summary>
		public string Title
		{
			get => _title;
			set
			{
				_title = value;
				RaisePropertyChanged(nameof(Title));
			}
		}

		public delegate void StartContentReceiveEventHandler(object sender, EventArgs e);
		public StartContentReceiveEventHandler StartContentReceiveEvent;

		public delegate void FinisContentReceiveEventHandler(object sender, EventArgs e);
		public FinisContentReceiveEventHandler FinishContentReceiveEvent;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ContentWindowViewModel()
		{
			Title = string.Empty;
			Content = string.Empty;
		}

		/// <summary>
		/// Property of content.
		/// </summary>
		public string Content
		{
			get => _content;
			set
			{
				_content = value;
				RaisePropertyChanged(nameof(Content));
			}
		}

		/// <summary>
		/// Add item to content.
		/// </summary>
		/// <param name="item">Item to add to content.</param>
		public void Append(string item)
		{
			Content += item;
			Content += Environment.NewLine;
		}

		/// <summary>
		/// Refresh (all clear) content.
		/// </summary>
		public void Refresh()
		{
			Content = string.Empty;
		}

		/// <summary>
		/// Data received event handler
		/// </summary>
		/// <param name="sender">Event sender</param>
		/// <param name="e">Event argument.</param>
		public void OnContentReceived(object sender, ContentReceivedEventArgs e)
		{
			Append(e.Data);
		}

		/// <summary>
		/// Data received event handler
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event argument.</param>
		public void OnDataReceived(object sender, DataReceivedEventArgs e)
		{
			Append(e.Data);
		}

		/// <summary>
		/// Start receiving data event handler.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event argument.</param>
		public void OnDataReceiveStart(object sender, EventArgs e)
		{
			StartContentReceiveEvent?.Invoke(this, e);
		}

		/// <summary>
		/// Refresh received data event handler.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event argument.</param>
		public void OnDataRefresh(object sender, EventArgs e)
		{
			Refresh();
		}

		/// <summary>
		/// Finish receiving data event handler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnDataFinished(object sender, EventArgs e)
		{
			FinishContentReceiveEvent?.Invoke(sender, e);
		}

		/// <summary>
		/// Raise event to start data receiving.
		/// </summary>
		/// <param name="e">Event argument.</param>
		public void RaiseDataReceiveStartEvent(EventArgs e)
		{
			this.OnDataReceiveStart(this, e);
		}

		/// <summary>
		/// Raise event to finish data receiving.
		/// </summary>
		/// <param name="e">Event argument.</param>
		public void RaiseDataReceiveFinishedEvent(EventArgs e)
		{
			this.OnDataFinished(this, e);
		}
	}
}
