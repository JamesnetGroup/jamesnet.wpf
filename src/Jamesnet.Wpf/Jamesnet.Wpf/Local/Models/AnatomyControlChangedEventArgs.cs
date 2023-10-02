using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamesnet.Wpf.Local.Models
{
    internal class AnatomyControlChangedEventArgs : EventArgs
    {
        public AnatomyCollection Controls { get; internal set; }
    }
}
