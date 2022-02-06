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

		protected delegate void DataReceivedEventHandler(object sender, ContentReceivedEventArgs e);
		protected DataReceivedEventHandler OnDataReceivedEvent;

		/// <summary>
		/// View of title.
		/// </summary>
		public string ViewTitle { get; set; }

		/// <summary>
		/// Data received event handler.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event argument.</param>
		public void OnDataReceived(object sender, ContentReceivedEventArgs e)
		{
			OnDataReceivedEvent?.Invoke(this, e);
		}

		/// <summary>
		/// Open content window.
		/// </summary>
		public void Open()
		{
			_viewModel = new ContentWindowViewModel()
			{
				Title = ViewTitle
			};
			OnDataReceivedEvent += _viewModel.OnDataReceived;
			_view = new CountrySideEngineer.ContentWindow.View.ContentWindowView()
			{
				DataContext = _viewModel
			};
			_view.Show();
		}

		/// <summary>
		/// Close content window.
		/// </summary>
		public void Close()
		{
			OnDataReceivedEvent -= _viewModel.OnDataReceived;
			_view.Close();
		}
	}
}
