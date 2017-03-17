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

namespace Argus.Win
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        double MiniCorner = 156;
        bool isDown = false;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(this.BigBorder, (ConCanvas.ActualWidth - this.BigBorder.ActualWidth) / 2);
            Canvas.SetTop(this.BigBorder, (ConCanvas.ActualHeight - this.BigBorder.ActualHeight) / 2);
        }

        private void BigBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDown = true;
        }

        private void BigBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDown)
            {
                //Point Sp = e.GetPosition(null);
                //double left = Sp.X - BigBorder.ActualWidth / 2;
                //double top = Sp.Y - BigBorder.ActualHeight / 2 - -10;// 50;
                //double width = Sp.X - 5;
                //double height = Sp.Y  -5;// 55;
                //if (left < MiniCorner)
                //{
                //    left = MiniCorner - 5;
                //    width = MiniCorner + (BigBorder.ActualWidth / 2 - 10);
                //}
                //else if (left > SystemParameters.PrimaryScreenWidth - MiniCorner)
                //{//为了平整右和下都-40
                //    left = SystemParameters.PrimaryScreenWidth - MiniCorner - 5;// - 40;
                //    width = SystemParameters.PrimaryScreenWidth - MiniCorner + (BigBorder.ActualWidth / 2 - 10);// - 40;
                //}
                //if (top < MiniCorner)
                //{
                //    top = MiniCorner - (BigBorder.ActualWidth / 2 - 10);
                //    height = MiniCorner;
                //}
                //else if (top > SystemParameters.PrimaryScreenHeight - MiniCorner - -10)// 50)
                //{//为了平整右和下都-40
                //    top = SystemParameters.PrimaryScreenHeight - MiniCorner - 50;// - 40;
                //    height = SystemParameters.PrimaryScreenHeight - MiniCorner -10//-50 
                //        + (BigBorder.ActualWidth / 2 - 10);// - 40;
                //}
                //this.grid.ColumnDefinitions[0].Width = new GridLength(width, GridUnitType.Pixel);
                //this.grid.RowDefinitions[0].Height = new GridLength(height, GridUnitType.Pixel);
                //Canvas.SetLeft(this.BigBorder, left);
                //Canvas.SetTop(this.BigBorder, top);
                isDown = false;
            }
        }

        private void BigBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                Point Sp = e.GetPosition(null);
                double left = Sp.X - BigBorder.ActualWidth / 2;
                double top = Sp.Y - BigBorder.ActualHeight / 2 - -10;// 50;
                double width = Sp.X - 5;
                double height = Sp.Y - 5;// 55;
                if (left < MiniCorner)
                {
                    left = MiniCorner - 5;
                    width = MiniCorner + (BigBorder.ActualWidth / 2 - 10);
                }
                else if (left > SystemParameters.PrimaryScreenWidth - MiniCorner)
                {//为了平整右和下都-40
                    left = SystemParameters.PrimaryScreenWidth - MiniCorner - 5;// - 40;
                    width = SystemParameters.PrimaryScreenWidth - MiniCorner + (BigBorder.ActualWidth / 2 - 10);// - 40;
                }
                if (top < MiniCorner)
                {
                    top = MiniCorner - (BigBorder.ActualWidth / 2 - 10);
                    height = MiniCorner;
                }
                else if (top > SystemParameters.PrimaryScreenHeight - MiniCorner - -10)// 50)
                {//为了平整右和下都-40
                    top = SystemParameters.PrimaryScreenHeight - MiniCorner - 50;// - 40;
                    height = SystemParameters.PrimaryScreenHeight - MiniCorner - 10//-50 
                        + (BigBorder.ActualWidth / 2 - 10);// - 40;
                }
                this.grid.ColumnDefinitions[0].Width = new GridLength(width, GridUnitType.Pixel);
                this.grid.RowDefinitions[0].Height = new GridLength(height, GridUnitType.Pixel);
                Canvas.SetLeft(this.BigBorder, left);
                Canvas.SetTop(this.BigBorder, top);
            }
        }
    }
}