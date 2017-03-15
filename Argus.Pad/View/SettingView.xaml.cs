using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Argus.Pad
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SettingView : Page
    {
        public SettingView()
        {
            this.InitializeComponent();
            //Storyboard storyboard = new Storyboard();

            //DoubleAnimation animation = new DoubleAnimation();
            //animation.From = 40;
            //animation.To = 800;
            //animation.Duration = new Duration(TimeSpan.FromMilliseconds(5000));
            //animation.EnableDependentAnimation = true;// 没有这一句，动画就不动了  

            //Storyboard.SetTarget(animation, btn);
            //Storyboard.SetTargetProperty(animation, "(UIElement.Height)");

            //storyboard.Children.Add(animation);
            //storyboard.Begin();

            Storyboard storyboard = new Storyboard();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 10;
            animation.To = 500;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(3000));
            //animation.EnableDependentAnimation = true;// 没有这一句，动画也可以动  

            Storyboard.SetTarget(animation, btn);
            Storyboard.SetTargetProperty(animation, "(Canvas.Left)");

            storyboard.Children.Add(animation);
            storyboard.Begin();

            storyboard = new Storyboard();
            animation = new DoubleAnimation();
            animation.From = 10;
            animation.To = 500;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(3000));
            //animation.EnableDependentAnimation = true;// 没有这一句，动画也可以动  

            Storyboard.SetTarget(animation, btn);
            Storyboard.SetTargetProperty(animation, "(Canvas.Top)");

            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}
