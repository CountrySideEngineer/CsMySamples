using CountrySideEngineer.ContentWindow.Model;
using CountrySideEngineer.ContentWindow.View;
using CountrySideEngineer.ContentWindow.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySideEngineer.ContentWindow
{
	public class ContentWindow
	{
		/// <summary>
		/// ViewMolde object of ContentWindowView.
		/// </summary>
		protected ContentWindowViewModel _viewModel;

		/// <summary>
		/// ContentWindowView object
		/// </summary>
		protected ContentWindowView _view;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ContentWindow()
		{
			_viewModel = null;
			ViewTitle = string.Empty;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="title"></param>
		public ContentWindow(string title)
		{
			_viewModel = null;
			ViewTitle = title;
		}

		protected delegate void ContentReceivedEventHandler(object sender, ContentReceivedEventArgs e);
		protected ContentReceivedEventHandler ContentReceivedEvent;

		protected delegate void ContentRefreshEventHandler(object sender, EventArgs e);
		protected ContentRefreshEventHandler ContentRefreshEvent;

		protected delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);
		protected DataReceivedEventHandler DataReceivedEvent;

		/// <summary>
		/// View of title.
		/// </summary>
		public string ViewTitle { get; set; }

		/// <summary>
		/// Data received event handler.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event argument.</param>
		public void OnContentReceived(object sender, ContentReceivedEventArgs e)
		{
			ContentReceivedEvent?.Invoke(sender, e);
		}

		/// <summary>
		/// Data received event handler.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event argument.</param>
		public void OnDataReceived(object sender, DataReceivedEventArgs e)
		{
			DataReceivedEvent?.Invoke(sender, e);
		}

		/// <summary>
		/// Data refresh request event handler.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event argument.</param>
		public void OnDataRefresh(object sender, EventArgs e)
		{
			ContentRefreshEvent?.Invoke(sender, e);
		}

		/// <summary>
		/// Open content window.
		/// </summary>
		public void Start()
		{
			_viewModel = new ContentWindowViewModel()
			{
				Title = ViewTitle
			};
			DataReceivedEvent += _viewModel.OnDataReceived;
			ContentReceivedEvent += _viewModel.OnContentReceived;
			ContentRefreshEvent += _viewModel.OnDataRefresh;
			_view = new CountrySideEngineer.ContentWindow.View.ContentWindowView()
			{
				DataContext = _viewModel
			};
			_viewModel.RaiseDataReceiveStartEvent(null);
		}

		/// <summary>
		/// Close content window.
		/// </summary>
		public void Finish()
		{
			DataReceivedEvent -= _viewModel.OnDataReceived;
			ContentReceivedEvent -= _viewModel.OnContentReceived;
			ContentRefreshEvent -= _viewModel.OnDataRefresh;
			_viewModel.RaiseDataReceiveFinishedEvent(null);
		}
	}
}
