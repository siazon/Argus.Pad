﻿using System;
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

namespace Argus.Win.View
{
    /// <summary>
    /// DectionResultView.xaml 的交互逻辑
    /// </summary>
    public partial class DectionResultView : UserControl
    {
        public DectionResultView()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Text_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextSudo_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid MainControl = (Grid)this.Parent;
            MainControl.Children.Clear();
            DectionView view = new DectionView();
            MainControl.Children.Add(view);
        }
    }
}
