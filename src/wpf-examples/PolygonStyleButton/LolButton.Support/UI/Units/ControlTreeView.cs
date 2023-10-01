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

namespace LolButton.Support.UI.Units
{
    public class ControlTreeView : TreeView
    {
        static ControlTreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ControlTreeView), new FrameworkPropertyMetadata(typeof(ControlTreeView)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ControlTreeItem();
        }
    }
}
