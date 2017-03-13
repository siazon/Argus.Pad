using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Argus.Pad
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainView : BasePage
    {
        public MainView()
        {
            this.InitializeComponent();
            this.Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(this.BigBorder, (ConCanvas.ActualWidth - this.BigBorder.ActualWidth) / 2);
            Canvas.SetTop(this.BigBorder, (ConCanvas.ActualHeight - this.BigBorder.ActualHeight) / 2);
        }
        PointerPoint p;
        bool isDown = false;
        private void border_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            isDown = true;
            p = e.GetCurrentPoint(null);
        }


        private void grid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            //Vector p1 = (e.GetPosition(null)) - p;
            //ChangeX(p1.X, p1.Y);
            if (isDown)
            {
                PointerPoint Sp = e.GetCurrentPoint(null);
                this.grid.ColumnDefinitions[0].Width = new GridLength(Sp.Position.X - 5, GridUnitType.Pixel);
                this.grid.RowDefinitions[0].Height = new GridLength(Sp.Position.Y - 53, GridUnitType.Pixel);
                Canvas.SetLeft(this.BigBorder, Sp.Position.X - BigBorder.ActualWidth / 2);
                Canvas.SetTop(this.BigBorder, Sp.Position.Y - BigBorder.ActualHeight / 2 - 50);
                isDown = false;
            }
        }
    }
}
