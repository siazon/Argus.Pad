
using Argus.Pad.Model;
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
    public sealed partial class DectionResultView : NotifyBasePage
    {

        BaseLayoutView mainView;
        private DectionResult _result;


        public DectionResult Result
        {
            get { return _result; }
            set
            {
                _result = value;
                this.OnPropertyChanged("Result");
            }
        }
        private TestOrder _order;

        public TestOrder Order
        {
            get { return _order; }
            set
            {
                _order = value;
                this.OnPropertyChanged("Order");
            }
        }


       


        public DectionResultView()
        {
            this.InitializeComponent();
            // this.DataContext = this;
            _result = new DectionResult();
            _result.ResultRange = "100-300";
            _result.ResultTips = "ABC";
            _result.ResultValue = "质控---标准光源测试呈阴性";
            Order = new TestOrder() { Age=18, Doctor="刘医生", Gender="男", Name="王大锤", Operater="王小利", Remark="请尊医嘱", TestAddr="南山医院", TestTime=DateTime.Now };
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            mainView = (BaseLayoutView)e.Parameter;
            if (mainView.Parameter != null)
                TestTitle.Text = mainView.Parameter.ToString();
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
            mainView.Parameter = TestTitle.Text;
            mainView.NavigatedBack();
        }

        private void btnSave_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Order.Name = "ggg";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Order.Name = "ggg";
        }
    }
  

}
