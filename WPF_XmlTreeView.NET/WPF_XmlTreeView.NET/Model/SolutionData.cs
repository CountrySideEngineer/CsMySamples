using Accessibility;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;
using WPF_XmlTreeView.NET.ViewModel;

namespace WPF_XmlTreeView.NET.Model
{
	[XmlRoot("TestSolution")]
	internal class ProjectItem : ViewModelBase
	{
		protected string _name = string.Empty;

		[XmlAttribute(nameof(Name))]
		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				RaisePropertyChanged();
			}
		}

		protected string _path = string.Empty;

		[XmlAttribute(nameof(Path))]
		public string Path
		{
			get => _path;
			set
			{
				_path = value;
				RaisePropertyChanged();
			}
		}

		protected IEnumerable<ProjectItem>? _items = null;

		[XmlElement("Item")]
		public IEnumerable<ProjectItem>? Items
		{
			get => _items;
			set
			{
				_items = value;
				RaisePropertyChanged();
			}
		}

		protected string _typeName = string.Empty;

		[XmlAttribute(nameof(TypeName))]
		public string? TypeName
		{
			get => _typeName;
			set
			{
				_typeName = value;
				RaisePropertyChanged();
			}
		}
	}

	internal class ProjectItemEx : ProjectItem
	{
		protected string _exName = string.Empty;

		public string ExName
		{
			get => _exName;
			set
			{
				_exName = value;
				RaisePropertyChanged();
			}
		}
	}
}
