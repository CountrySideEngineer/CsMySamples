using CountrySideEngineer.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RichTextSample
{
	internal class RichTextSampleViewModel : ViewModelBase
	{
		protected string _content = string.Empty;

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
		/// Constructor.
		/// </summary>
		public RichTextSampleViewModel() { }

		public void LoadContent()
		{
			string filePath = @".\..\CMultiple_test.calc_002.log";
			using (var reader = new StreamReader(filePath))
			{
				string content = reader.ReadToEnd();
				Content = content;
			}
		}

	}
}
