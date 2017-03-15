using Argus.Pad.Common;
using Argus.Pad.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        double MiniCorner = 156;
       public Layouts Layout;
        public MainView()
        {
            this.InitializeComponent();
            this.Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(this.BigBorder, (ConCanvas.ActualWidth - this.BigBorder.ActualWidth) / 2);
            Canvas.SetTop(this.BigBorder, (ConCanvas.ActualHeight - this.BigBorder.ActualHeight) / 2);
            this.Layout = Layouts.LeftUp;
            LeftUpFrame.Navigate(typeof(BaseLayoutView), this);
            this.Layout = Layouts.LeftBottom;
            LeftBottonFrame.Navigate(typeof(BaseLayoutView), this);
            this.Layout = Layouts.RightUp;
            RightUpFrame.Navigate(typeof(BaseLayoutView), this);
            this.Layout = Layouts.RightBotton;
            RightBottonFrame.Navigate(typeof(BaseLayoutView), this);
            
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
                double left = Sp.Position.X - BigBorder.ActualWidth / 2;
                double top = Sp.Position.Y - BigBorder.ActualHeight / 2 - 50;
                double width = Sp.Position.X - 5;
                double height = Sp.Position.Y - 55;
                if (left < MiniCorner)
                {
                    left = MiniCorner-5;
                    width = MiniCorner + (BigBorder.ActualWidth / 2 - 10);
                }
                else if (left > Window.Current.Bounds.Width - MiniCorner)
                {//为了平整右和下都-40
                    left = Window.Current.Bounds.Width - MiniCorner-5-40;
                    width = Window.Current.Bounds.Width - MiniCorner + (BigBorder.ActualWidth / 2 - 10)-40;
                }
                if (top < MiniCorner)
                {
                    top = MiniCorner - (BigBorder.ActualWidth / 2 - 10);
                    height = MiniCorner;
                }
                else if (top > Window.Current.Bounds.Height - MiniCorner-50)
                {//为了平整右和下都-40
                    top = Window.Current.Bounds.Height - MiniCorner - 50-40;
                    height = Window.Current.Bounds.Height - MiniCorner - 50 + (BigBorder.ActualWidth / 2 - 10)-40;
                }
                this.grid.ColumnDefinitions[0].Width = new GridLength(width, GridUnitType.Pixel);
                this.grid.RowDefinitions[0].Height = new GridLength(height, GridUnitType.Pixel);
                Canvas.SetLeft(this.BigBorder, left);
                Canvas.SetTop(this.BigBorder, top);
                isDown = false;
            }
        }
        public void DragMove(Layouts Layout)
        {
            double left = Canvas.GetLeft(BigBorder);
            double top = Canvas.GetTop(BigBorder);
            double width = this.grid.ColumnDefinitions[0].Width.Value;
            double height = this.grid.RowDefinitions[0].Height.Value;
            switch (Layout)
            {
                case Layouts.LeftUp://为了平整右和下都-40
                    left = Window.Current.Bounds.Width - MiniCorner - 5-40;
                    width = Window.Current.Bounds.Width - MiniCorner + (BigBorder.ActualWidth / 2 - 10)-40;
                    top = Window.Current.Bounds.Height - MiniCorner - 50-40;
                    height = Window.Current.Bounds.Height - MiniCorner - 50 + (BigBorder.ActualWidth / 2 - 10)-40;
                    break;
                case Layouts.LeftBottom:
                    left = Window.Current.Bounds.Width - MiniCorner - 5-40;
                    width = Window.Current.Bounds.Width - MiniCorner + (BigBorder.ActualWidth / 2 - 10)-40;
                    top = MiniCorner - (BigBorder.ActualWidth / 2 - 10);
                    height = MiniCorner;
                    break;
                case Layouts.RightUp:
                    left = MiniCorner - 5;
                    width = MiniCorner + (BigBorder.ActualWidth / 2 - 10);
                    top = Window.Current.Bounds.Height - MiniCorner - 50-40;
                    height = Window.Current.Bounds.Height - MiniCorner - 50 + (BigBorder.ActualWidth / 2 - 10)-40;
                    break;
                case Layouts.RightBotton:
                    left = MiniCorner - 5;
                    width = MiniCorner + (BigBorder.ActualWidth / 2 - 10);
                    top = MiniCorner - (BigBorder.ActualWidth / 2 - 10);
                    height = MiniCorner;
                    break;
                default:
                    break;
            }
            this.grid.ColumnDefinitions[0].Width = new GridLength(width, GridUnitType.Pixel);
            this.grid.RowDefinitions[0].Height = new GridLength(height, GridUnitType.Pixel);
            Canvas.SetLeft(this.BigBorder, left);
            Canvas.SetTop(this.BigBorder, top);
        }
     
    }
}
