using System.Windows;
using System.Windows.Controls;

namespace Jamesnet.Wpf.UI.Units
{
    internal class ControlTreeView : TreeView
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
