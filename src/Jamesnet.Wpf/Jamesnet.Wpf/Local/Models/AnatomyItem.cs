using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Jamesnet.Wpf.Local.Models
{
    internal class AnatomyItem
    {
        public string Name { get; internal set; }
        public IconType IconType { get; internal set; }
        public Type Type { get; internal set; }
        public Type ControlType { get; internal set; }
        public DependencyObject Instance { get; internal set; }
        public List<AnatomyItem> Children { get; internal set; }
        public ObservableCollection<DetailInfo> Items { get; set; }

    }
}
