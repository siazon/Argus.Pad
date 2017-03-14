using Argus.Pad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Pad.Model
{
    public class DetectionModel : NotificationObject
    {
        private string text="检 测";

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                this.RaisePropertyChanged("Text");
            }
        }
        public void Copy(object obj)
        {
            Text += ">";
        }

    }
}
