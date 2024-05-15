using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_XmlTreeView.NET.Model
{
	[XmlRoot("TestSolution")]
	internal class SolutionData
	{
		[XmlAttribute(nameof(Name))]
		public string Name { get; set; } = "";

		[XmlElement("TestProject")]
		public IEnumerable<ProjectItem>? Items { get; set; } = null;
	}

	internal class ProjectItem
	{
		[XmlAttribute(nameof(Name))]
		public string Name { get; set; } = string.Empty;

		[XmlAttribute(nameof(Path))]
		public string Path { get; set; } = string.Empty;

		[XmlElement("Item")]
		public IEnumerable<ProjectItem>? Items { get; set; } = null;
	}
}
