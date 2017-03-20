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
    /// DetectionView.xaml 的交互逻辑
    /// </summary>
    public partial class DetectionView : UserControl
    {
        public DetectionView()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid MainControl = (Grid)this.Parent;
            MainControl.Children.Clear();
            PreDectionView view = new PreDectionView();
            MainControl.Children.Add(view);

        }
    }
}
