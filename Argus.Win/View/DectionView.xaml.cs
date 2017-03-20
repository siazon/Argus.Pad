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
    /// DectionView.xaml 的交互逻辑
    /// </summary>
    public partial class DectionView : UserControl
    {
        public System.Timers.Timer timeCounter = new System.Timers.Timer(10);
        DateTime countDownTime = new DateTime(2017, 1, 1, 0, 15, 0);
        public DectionView(string TestType="")
        {
            InitializeComponent();
            timeCounter.Elapsed += TimeCounter_Elapsed;
            timeCounter.Start();
            txtItemName.Text = TestType;

        }
        private void TimeCounter_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)(() =>
            {
                countDownTime = countDownTime.AddSeconds(-1);
                txtTimeCount.Text = string.Format("{0}:{1}", countDownTime.Minute.ToString().PadLeft(2, '0'), countDownTime.Second.ToString().PadLeft(2, '0'));
                if (countDownTime.Year < 2017)
                {
                    timeCounter.Stop();
                    Grid MainControl = (Grid)this.Parent;
                    MainControl.Children.Clear();
                    DectionResultView view = new DectionResultView();
                    MainControl.Children.Add(view);
                }
            }));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid MainControl = (Grid)this.Parent;
            MainControl.Children.Clear();
            DectionResultView view = new DectionResultView();
            MainControl.Children.Add(view);
        }
    }
}
