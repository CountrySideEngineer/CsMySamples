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
			string filePath = @"E:\development\googletest_gui\dev\src\bin\Release\netframework\log\SampleTest_NG\output\CAdd_test.calc_001_20230505072007.log";
			using (var reader = new StreamReader(filePath))
			{
				string content = reader.ReadToEnd();
				Content = content;
			}
		}

	}
}
