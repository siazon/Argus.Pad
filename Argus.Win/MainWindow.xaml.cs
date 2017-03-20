using Argus.Win.View;
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
using System.Windows.Media.Animation;
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
            SystemMemory.Instance.MainWindow = this;
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(this.BigBorder, (ConCanvas.ActualWidth - this.BigBorder.ActualWidth) / 2);
            Canvas.SetTop(this.BigBorder, (ConCanvas.ActualHeight - this.BigBorder.ActualHeight) / 2);
            BaseLayoutView view = new BaseLayoutView() { _CurreLayout = Layouts.LeftUp };
            this.LeftUpFrame.Children.Add(view);

            view = new BaseLayoutView() { _CurreLayout = Layouts.RightUp };
            this.RightUpFrame.Children.Add(view);

            view = new BaseLayoutView() { _CurreLayout = Layouts.LeftBottom };
            this.LeftBottonFrame.Children.Add(view);

            view = new BaseLayoutView() { _CurreLayout = Layouts.RightBotton };
            this.RightBottonFrame.Children.Add(view);
        }

        private void BigBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (e.ClickCount == 1)
            {
                var timer = new System.Timers.Timer(100);
                timer.AutoReset = false;
                timer.Elapsed += new System.Timers.ElapsedEventHandler((o, ex) => element.Dispatcher.Invoke(new Action(() =>
                {
                    var timer2 = (System.Timers.Timer)element.Tag;
                    timer2.Stop();
                    timer2.Dispose();
                    UIElement_Click(element, e);
                })));
                timer.Start();
                element.Tag = timer;
            }
            if (e.ClickCount > 1)
            {
                var timer = element.Tag as System.Timers.Timer;
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    UIElement_DoubleClick(sender, e);
                }
            }

        }
        private void UIElement_Click(object sender, MouseButtonEventArgs e)
        {
            isDown = true;
        }
        private void UIElement_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            isDown = false;
            double left = ConCanvas.ActualWidth / 2 - 15;
            double top = ConCanvas.ActualHeight / 2 - 15;
            double width = SystemParameters.PrimaryScreenWidth / 2;
            double height = SystemParameters.PrimaryScreenHeight / 2;
            //if (System.Configuration.ConfigurationManager.AppSettings["IsAnimation"].ToString() == "1")
            //{
            //    AnimationMoveTo(new Point(left, top), width, height);
            //}
            //else
            {
                this.grid.ColumnDefinitions[0].Width = new GridLength(width, GridUnitType.Pixel);
                this.grid.RowDefinitions[0].Height = new GridLength(height, GridUnitType.Pixel);
                Canvas.SetLeft(this.BigBorder, left);
                Canvas.SetTop(this.BigBorder, top);
            }

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
        Storyboard sbDock;
        Storyboard srDock;
        Storyboard storyboard;
        private void BigBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                if (sbDock!=null)
                {
                    sbDock.Stop();
                }
                if (srDock != null)
                {
                    srDock.Stop();
                }
                if (storyboard != null)
                {
                    storyboard.Stop();
                }
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
                else if (top > SystemParameters.PrimaryScreenHeight - MiniCorner - 10)// 50)
                {//为了平整右和下都-40
                    top = SystemParameters.PrimaryScreenHeight - MiniCorner - 10;// - 40;
                    height = SystemParameters.PrimaryScreenHeight - MiniCorner - 10//-50 
                        + (BigBorder.ActualWidth / 2 - 10);// - 40;
                }


                this.grid.ColumnDefinitions[0].Width = new GridLength(width, GridUnitType.Pixel);
                this.grid.RowDefinitions[0].Height = new GridLength(height, GridUnitType.Pixel);
                Canvas.SetLeft(this.BigBorder, left);
                Canvas.SetTop(this.BigBorder, top);


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
                    left = SystemParameters.PrimaryScreenWidth - MiniCorner - 5;
                    width = SystemParameters.PrimaryScreenWidth - MiniCorner + (BigBorder.ActualWidth / 2 - 10);
                    top = SystemParameters.PrimaryScreenHeight - MiniCorner - 50;
                    height = SystemParameters.PrimaryScreenHeight - MiniCorner - 50 + (BigBorder.ActualWidth / 2 - 10);
                    break;
                case Layouts.LeftBottom:
                    left = SystemParameters.PrimaryScreenWidth - MiniCorner - 5;
                    width = SystemParameters.PrimaryScreenWidth - MiniCorner + (BigBorder.ActualWidth / 2 - 10);
                    top = MiniCorner - (BigBorder.ActualWidth / 2 - 10);
                    height = MiniCorner;
                    break;
                case Layouts.RightUp:
                    left = MiniCorner - 5;
                    width = MiniCorner + (BigBorder.ActualWidth / 2 - 10);
                    top = SystemParameters.PrimaryScreenHeight - MiniCorner - 50;
                    height = SystemParameters.PrimaryScreenHeight - MiniCorner - 50 + (BigBorder.ActualWidth / 2 - 10);
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

            if (System.Configuration.ConfigurationManager.AppSettings["IsAnimation"].ToString() == "1")
            {
                AnimationMoveTo(new Point(left, top), width, height);
            }
            else
            {
                this.grid.ColumnDefinitions[0].Width = new GridLength(width, GridUnitType.Pixel);
                this.grid.RowDefinitions[0].Height = new GridLength(height, GridUnitType.Pixel);
                Canvas.SetLeft(this.BigBorder, left);
                Canvas.SetTop(this.BigBorder, top);
            }

        }
       
        private void AnimationMoveTo(Point deskPoint, double width, double height)
        {
             sbDock = this.FindResource("sbDock") as Storyboard;
            if (sbDock != null)
            {
                SplineDoubleKeyFrame sdKeyFrame1 = new SplineDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)));
                //(sbDock.Children[0] as DoubleAnimationUsingKeyFrames).KeyFrames.Clear();
                //(sbDock.Children[0] as DoubleAnimationUsingKeyFrames).KeyFrames.Add(sdKeyFrame1);
                (sbDock.Children[0] as GridLengthAnimation).From = new GridLength(this.grid.ColumnDefinitions[0].Width.Value, GridUnitType.Pixel);
                (sbDock.Children[0] as GridLengthAnimation).To = new GridLength(width, GridUnitType.Pixel);

                sbDock.Begin();
                
            }
             srDock = this.FindResource("srDock") as Storyboard;
            if (srDock != null)
            {
                SplineDoubleKeyFrame sdKeyFrame1 = new SplineDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)));
                //(srDock.Children[0] as DoubleAnimationUsingKeyFrames).KeyFrames.Clear();
                //(srDock.Children[0] as DoubleAnimationUsingKeyFrames).KeyFrames.Add(sdKeyFrame1);
                (srDock.Children[0] as GridLengthAnimation).From = new GridLength(this.grid.RowDefinitions[0].Height.Value, GridUnitType.Pixel);
                (srDock.Children[0] as GridLengthAnimation).To = new GridLength(height, GridUnitType.Pixel);

                srDock.Begin();
            }

            //Point p = e.GetPosition(body);  

            Point curPoint = new Point();
            curPoint.X = Canvas.GetLeft(BigBorder);
            curPoint.Y = Canvas.GetTop(BigBorder);

            double _s = System.Math.Sqrt(Math.Pow((deskPoint.X - curPoint.X), 2) + Math.Pow((deskPoint.Y - curPoint.Y), 2));

            double _secNumber = (_s / 1000) * 500;

             storyboard = new Storyboard();

            //创建X轴方向动画  

            DoubleAnimation doubleAnimation = new DoubleAnimation(

              Canvas.GetLeft(BigBorder),

              deskPoint.X,
               new Duration(TimeSpan.FromSeconds(1))
            //  new Duration(TimeSpan.FromMilliseconds(_secNumber))

            );
            Storyboard.SetTarget(doubleAnimation, BigBorder);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(doubleAnimation);

            //创建Y轴方向动画  

            doubleAnimation = new DoubleAnimation(
              Canvas.GetTop(BigBorder),
              deskPoint.Y,
              new Duration(TimeSpan.FromSeconds(1))
            // new Duration(TimeSpan.FromMilliseconds(_secNumber))
            );
            Storyboard.SetTarget(doubleAnimation, BigBorder);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation);

            //动画播放  

            storyboard.Begin();


        }
    }


}
