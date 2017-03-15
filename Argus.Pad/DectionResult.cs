using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Pad
{
   public class DectionResult : INotifyPropertyChanged
    {
        private String _resultValue;

        public String ResultValue
        {
            get { return _resultValue; }
            set
            {
                _resultValue = value;
                OnPropertyChanged();
            }
        }

        private String _resultRange;
        public String ResultRange
        {
            get { return _resultRange; }
            set
            {
                _resultRange = value;
                OnPropertyChanged();
            }
        }

        private String _resultTips;
        public String ResultTips
        {
            get { return _resultTips; }
            set
            {
                _resultTips = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
