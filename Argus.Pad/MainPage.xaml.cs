using Argus.Pad.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Argus.Pad
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<NavLink> NavLinks = new List<NavLink>()
        {
            new NavLink() { Label = "主页", LinkType = typeof(MainView) },
            new NavLink() { Label = "设置", LinkType = typeof(SettingView) },
            new NavLink() { Label = "查询", LinkType = typeof(QueryView) }
        };
        private static MainPage _instance = null;
        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.SetTitleBar(null);
            _instance = this;
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            //ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }
        //右划后退
        public static void BackRequest()
        {
            if (_instance.contentFrame == null)
                return;
            if (_instance.contentFrame.CanGoBack)
            {
                _instance.contentFrame.GoBack();
            }

            //  _instance.contentFrame.Visibility = Visibility.Collapsed;
        }
        private void NavLinkClick(object sender, ItemClickEventArgs e)
        {
            NavLink link = e.ClickedItem as NavLink;
            if (link != null && link.LinkType != null)
                contentFrame.Navigate(link.LinkType);
            splitView.IsPaneOpen = false;
        }

        private void SplitViewToggle_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }
        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (contentFrame == null)
                return;
            if (contentFrame.CanGoBack)
            {
                e.Handled = true;
                contentFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                contentFrame.Navigate(typeof(MainView));
            }
            base.OnNavigatedTo(e);
        }
    }

}
