using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Jamesnet.Wpf.UI.Units
{
    internal class ControlTreeView : TreeView
    {
        static ControlTreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ControlTreeView), new FrameworkPropertyMetadata(typeof(ControlTreeView)));
        }

        public static readonly DependencyProperty SelectionCommandProperty = DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(ControlTreeView));

        public ICommand SelectionCommand
        {
            get => (ICommand)GetValue(SelectionCommandProperty);
            set => SetValue(SelectionCommandProperty, value);
        }


        public ControlTreeView()
        {
            SelectedItemChanged += TreeView_SelectedItemChanged;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem is not null)
            {
                SelectionCommand?.Execute(SelectedItem);
            }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ControlTreeItem();
        }
    }
}
