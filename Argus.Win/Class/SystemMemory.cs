using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Argus.Win
{
    public class SystemMemory
    {
        private static object _lock = new object();
        private static SystemMemory _instance;

        public static SystemMemory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = new SystemMemory();
                    }
                }
                return _instance;
            }
        }
        private IList<UserControl> _globalControls = new List<UserControl>();

        public IList<UserControl> GlobalControls
        {
            get { return _globalControls; }
            set { _globalControls = value; }
        }
        private MainWindow mainWindow;

        public MainWindow MainWindow
        {
            get { return mainWindow; }
            set { mainWindow = value; }
        }

    }
}
