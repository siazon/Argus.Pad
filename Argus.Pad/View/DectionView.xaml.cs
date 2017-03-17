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
    public sealed partial class DectionView : Page
    {
        DispatcherTimer timeCounter = new DispatcherTimer();
        BaseLayoutView mainView;
        DateTime countDownTime = new DateTime(2017, 1, 1, 0, 15, 0);
        public DectionView()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            mainView = (BaseLayoutView)e.Parameter;
            if (mainView.Parameter != null)
                txtItemName.Text = mainView.Parameter.ToString();
            timeCounter.Interval = new TimeSpan(100000);
            timeCounter.Tick += TimeCounter_Tick;
            timeCounter.Start();
            txtTimeCount.Text = string.Format("{0}:{1}", countDownTime.Minute.ToString().PadLeft(2, '0'), countDownTime.Second.ToString().PadLeft(2, '0'));

        }

        private void TimeCounter_Tick(object sender, object e)
        {
            countDownTime = countDownTime.AddSeconds(-1);
            txtTimeCount.Text = string.Format("{0}:{1}", countDownTime.Minute.ToString().PadLeft(2, '0'), countDownTime.Second.ToString().PadLeft(2, '0'));
            if (countDownTime.Year < 2017)
            {
                timeCounter.Stop();
                mainView.NavigatedTo(typeof(DectionResultView));
            }
        }

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            mainView.Parameter = txtItemName.Text;
            mainView.NavigatedTo(typeof(DectionResultView));
        }
    }
}
