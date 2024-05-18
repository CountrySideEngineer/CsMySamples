using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_XmlTreeView.NET.ViewModel;

namespace WPF_XmlTreeView.NET.Selector
{
	internal class ControlContentSelector : DataTemplateSelector
	{
		public override DataTemplate? SelectTemplate(object item, DependencyObject container)
		{
			var element = container as FrameworkElement;
			var viewModel = item as MainWindowViewModel;
			if (element == null || viewModel == null)
			{
				return null;
			}

			string templateType = "";
			switch (viewModel.SelectedItem)
			{
				default:
					templateType = "";
					break;
			}

			return templateType == "" ? null : element.FindResource(templateType) as DataTemplate;
		}
	}
}
