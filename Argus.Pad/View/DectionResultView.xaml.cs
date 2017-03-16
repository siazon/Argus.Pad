
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
    public sealed partial class DectionResultView : Page
    {

        BaseLayoutView mainView;
        private DectionResult _result;

        public DectionResult Result
        {
            get { return _result; }
            set { _result = value;
               // this.OnPropertyChanged("Result");
            }
        }

        public DectionResultView()
        {
            this.InitializeComponent();
            //_result.ResultRange = "123";
            //_result.ResultTips = "123";
            //_result.ResultValue = "123";
            

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            mainView = (BaseLayoutView)e.Parameter;
        }
        private void Text_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextSudo_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            mainView.NavigatedBack();
        }
    }
 
}
