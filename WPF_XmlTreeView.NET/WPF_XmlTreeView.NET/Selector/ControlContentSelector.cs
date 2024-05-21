using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_XmlTreeView.NET.Model;
using WPF_XmlTreeView.NET.ViewModel;

namespace WPF_XmlTreeView.NET.Selector
{
	internal class ControlContentSelector : DataTemplateSelector
	{
		public override DataTemplate? SelectTemplate(object item, DependencyObject container)
		{
			var element = container as FrameworkElement;
			var content = item as ProjectItem;
			if (element == null || content == null)
			{
				return null;
			}

			string templateType = "";
			switch (content.TypeName)
			{
				case "Control_001":
					templateType = "A";
					break;

				case "Control_002":
					templateType = "B";
					break;

				default:
					templateType = "";
					break;
			}

			DataTemplate? template = templateType == "" ? null : element.FindResource(templateType) as DataTemplate;
			UserControl userControl = (UserControl)template.LoadContent();
			userControl.DataContext = content;

			content.Name += "_001";
			
			return template;
		}
	}
}
