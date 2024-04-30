using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPF_ViewSwitchedWithTreeView.View
{
	/// <summary>
	/// CustomTreeView.xaml の相互作用ロジック
	/// </summary>
	public partial class CustomTreeView : UserControl
	{
		public CustomTreeView()
		{
			InitializeComponent();
		}

		public delegate void SelectedItemNodeChanged(object sender, EventArgs e);
		public event SelectedItemNodeChanged SelectedItemChangedEventHandler;

		private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			object selectedItemIndex = this.TreeView.SelectedItem;
			SelectedItemChangedEventHandler?.Invoke(this, e);
		}
	}
}
