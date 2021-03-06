﻿using Argus.Pad.Common;
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
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Argus.Pad.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public partial class BaseLayoutView : Page
    {
        private Layouts _CurreLayout;
        public MainView MainView;
        public Object Parameter ;
        public BaseLayoutView()
        {
            this.InitializeComponent();
            this.Cover.Visibility = Visibility.Collapsed;
            this.SizeChanged += BaseLayoutView_SizeChanged;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainView = (MainView)e.Parameter;
            _CurreLayout = MainView.Layout;
            Frame rootFrame = Window.Current.Content as Frame;
            this.MainFram.Navigate(typeof(DetectionView), this);
        }
        public void NavigatedTo(Type type,object parameter=null)
        {
            this.Parameter = parameter;
            this.MainFram.Navigate(type, this);
        }
        public void NavigatedBack()
        {
            if (MainFram.CanGoBack)
            {
                MainFram.GoBack();
            }
        }
        private void BaseLayoutView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Cover.Visibility = Visibility.Collapsed;
            if (this.ActualHeight < 200)
            {
                this.Cover.Visibility = Visibility.Visible;
            }

            if (this.ActualWidth < 200)
            {
                this.Cover.Visibility = Visibility.Visible;
            }

        }

        private void Cover_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

            MainView.DragMove(_CurreLayout);
        }
    }
}
