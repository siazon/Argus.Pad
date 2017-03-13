using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Pad
{
    public class NavLink
    {
        public String Label { get; set; }
        public Type LinkType { get; set; }
        public override String ToString()
        {
            return Label;
        }
    }
}
