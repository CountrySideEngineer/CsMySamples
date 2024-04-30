using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_ViewSwitchedWithTreeView.Model;
using WPF_ViewSwitchedWithTreeView.View;

namespace WPF_ViewSwitchedWithTreeView
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		protected Dictionary<string, string> _ViewPathDictionary = new Dictionary<string, string>
		{
			{ "TreeItem1", "WPF_ViewSwitchedWithTreeView.View.CustomUserViewControl_001" },
			{ "TreeItem2", "WPF_ViewSwitchedWithTreeView.View.CustomUserViewControl_002" },
			{ "TreeItem3", "WPF_ViewSwitchedWithTreeView.View.CustomUserViewControl_003" },
			{ "TreeItem4", "WPF_ViewSwitchedWithTreeView.View.CustomUserViewControl_004" },
		};

		protected Dictionary<string, UIElement> _ViewDictionary = new Dictionary<string, UIElement>();

		public MainWindow()
		{
			InitializeComponent();

			this.CustomTreeView.SelectedItemChangedEventHandler += CustomTreeView_SelectedItemChangedEventHandler;
		}

		protected virtual void CustomTreeView_SelectedItemChangedEventHandler(object sender, EventArgs e)
		{
			var selectedItemInfo = (RoutedPropertyChangedEventArgs<object>)e;

			var selectedItem = (TreeNodeItem)selectedItemInfo.NewValue;
			var name = selectedItem.Name;

			var element = GetSelectedPage(name);
			ContentPresenter.Content = element;
		}

		protected virtual UIElement GetSelectedPage(string selectedName)
		{
			try
			{
				var element = _ViewDictionary[selectedName];
				return element;
			}
			catch (KeyNotFoundException)
			{
				var path = GetSelectedPath(selectedName);
				var type = Type.GetType(path);

				var element = (UIElement)Activator.CreateInstance(type);

				_ViewDictionary.Add(selectedName, element);

				return element;
			}
		}

		protected virtual string GetSelectedPath(string selectedName)
		{
			string path = _ViewPathDictionary[selectedName];

			return path;
		}
	}
}
