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
		}

		/// <summary>
		/// Data received event handler
		/// </summary>
		/// <param name="sender">Event sender</param>
		/// <param name="e">Event argument.</param>
		public void OnDataReceived(object sender, ContentReceivedEventArgs e)
		{
			Append(e.Data);
		}
	}
}
