using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Jamesnet.Wpf.Local.Models
{
    public class DetailInfo
    {
        public string Name { get; set; }
        public object Content { get; set; }
        public FrameworkElement Instance { get; internal set; }
    }
}
