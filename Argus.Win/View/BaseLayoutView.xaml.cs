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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Argus.Win.View
{
    /// <summary>
    /// BaseLayoutView.xaml 的交互逻辑
    /// </summary>
    public partial class BaseLayoutView : UserControl
    {
        public Layouts _CurreLayout;
        public BaseLayoutView()
        {
            InitializeComponent();
            Cover.Visibility = Visibility.Collapsed;
            this.SizeChanged += BaseLayoutView_SizeChanged;
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

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SystemMemory.Instance.MainWindow.DragMove(_CurreLayout);
        }
    }
}
