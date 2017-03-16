using Argus.Pad.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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
    public partial class PreDectionView : Page, INotifyPropertyChanged
    {
        #region 字段

        BaseLayoutView mainView;

        #endregion
        #region 属性
        private string testType;

        public string TestType
        {
            get { return testType; }
            set
            {
                testType = value;
                this.RaisePropertyChanged("TestType");
            }
        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public PreDectionView()
        {
            this.InitializeComponent();
            this.DataContext = this;

            FieldInfo[] enumFields = typeof(TestType).GetFields();
            foreach (FieldInfo field in enumFields)
            {
                if (!field.IsSpecialName)
                {
                    cboxTestType.Items.Add(field.Name);
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            mainView = (BaseLayoutView)e.Parameter;
        }
        private void btnCloseDoor_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            testType = cboxTestType.SelectedItem.ToString();
            mainView.NavigatedTo(typeof(DectionView));
        }
    }
}
