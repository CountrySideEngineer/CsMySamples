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

			try
			{
				DataTemplate template = (DataTemplate)element.FindResource(templateType);
				UserControl userControl = (UserControl)template.LoadContent();
				userControl.DataContext = content;

				return template;
			}
			catch (Exception ex)
			when ((ex is InvalidCastException)
				|| (ex is NullReferenceException)
				|| (ex is ResourceReferenceKeyNotFoundException))
			{
				return null;
			}
		}
	}
}
