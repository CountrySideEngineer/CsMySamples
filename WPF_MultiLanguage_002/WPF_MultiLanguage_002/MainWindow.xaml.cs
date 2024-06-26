﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPF_MultiLanguage_002
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ja");
            Thread.CurrentThread.CurrentUICulture = culture;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = Properties.Resources.ID_CONTENT_MESSAGE_BOX_CONTENT;
            string title = Properties.Resources.ID_CONTENT_MESSAGE_BOX_TITLE;

            MessageBox.Show(message, title, MessageBoxButton.OK);
        }
    }
}
