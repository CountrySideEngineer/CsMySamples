using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPF_XMLinTreeView
{
    internal class LineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TreeViewItem item = (TreeViewItem)value;
            ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(item);
            return itemsControl.ItemContainerGenerator.IndexFromContainer(item) == itemsControl.Items.Count - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
