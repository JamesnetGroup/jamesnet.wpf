using Jamesnet.Wpf.Controls;
using LolButton.Support.UI.Units;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LolButton
{
    public class App : JamesApplication
    {
        ControlTreeView treeView;
        StackPanel stack;
        Grid grid;

        protected override Window CreateShell()
        {
            //button.Loaded += Button_Loaded;

            treeView = new();

            grid = new();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            stack = new();
            stack.Children.Add(new PlayButton());
            stack.Children.Add(new Slider());

            grid.Children.Add(treeView);
            grid.Children.Add(stack);

            Grid.SetColumn(stack, 1);

            Window window = new DarkThemeWindow()
                .AddChild(grid)
                .CenterAlignContent()
                .ApplyThemeColors("#000000", "#000000", "#FFFFFF");

            window.Loaded += Window_Loaded;

            return window;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddControl(stack.Children[0]);
            AddControl(stack.Children[1]);

            treeView.ItemsSource = source;
            treeView.SelectedItemChanged += TreeView_SelectedItemChanged;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var control = e.NewValue as ControlInfo;

            List<DependencyObject> allChildren = new List<DependencyObject>();
            if (control.Instance is DependencyObject instance)
            {
                allChildren.Add(instance); // 여기서 인스턴스 자기 자신을 추가합니다.
            }
            allChildren.AddRange(GetAllChildren(control.Instance));

            DetailList detailList = new DetailList();
            //uniform.Columns = 3;
            //uniform.Background = Brushes.Black;

            List<DetailInfo> source1 = new();

            foreach (var child in allChildren)
            {
                if (child is FrameworkElement element)
                {
                    VisualBrush brush = new VisualBrush(element);
                    brush.Stretch = Stretch.None;

                    Rectangle rect = new Rectangle();
                    rect.Width = element.ActualWidth;
                    rect.Height = element.ActualHeight;
                    rect.Fill = brush;

                    var item = new DetailInfo();
                    item.Content = rect;
                    item.Name = element.GetType().Name;
                    item.Instance = element;
                    source1.Add(item);
                }
            }

            detailList.ItemsSource = source1;
            detailList.SelectionChanged += DetailList_SelectionChanged;
            Grid.SetColumn(detailList, 2);
            grid.Children.Add(detailList);
        }

        private void DetailList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox lbx && lbx.SelectedItem is DetailInfo info)
            {
                //info.Instance;
                PropertyPanel panel = new();
                panel.DataContext = info.Instance;

                Grid.SetColumn(panel, 3);
                grid.Children.Add(panel);
            }
        }

        private List<DependencyObject> GetAllChildren(DependencyObject parent)
        {
            var allChildren = new List<DependencyObject>();

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                allChildren.Add(child);

                allChildren.AddRange(GetAllChildren(child));
            }

            return allChildren;
        }


        List<ControlInfo> source = new List<ControlInfo>();

        void AddControl(object obj)
        {
            if (obj is DependencyObject dependencyObject)
            {
                ControlInfo controlInfo = new ControlInfo
                {
                    Name = obj.GetType().Name,
                    ControlType = obj.GetType(),
                    Instance = dependencyObject
                };

                AddChildControls(controlInfo, dependencyObject); // 자식 컨트롤들을 추가합니다.

                source.Add(controlInfo); // 루트 컨트롤만 source 리스트에 추가합니다.
            }
        }

        void AddChildControls(ControlInfo parentControlInfo, DependencyObject parentDependencyObject)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parentDependencyObject);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parentDependencyObject, i);
                ControlInfo childControlInfo = new ControlInfo
                {
                    Name = child.GetType().Name,
                    ControlType = child.GetType(),
                    Instance = child
                };
                parentControlInfo.Children.Add(childControlInfo); // 자식 ControlInfo를 Children 리스트에 추가합니다.

                if (child is DependencyObject childDependencyObject)
                    AddChildControls(childControlInfo, childDependencyObject); // 재귀적으로 하위 컨트롤들을 추가합니다.
            }
        }


    }

    public class ControlInfo
    {
        public string Name { get; set; }
        public Type ControlType { get; set; }
        public List<ControlInfo> Children { get; set; }
        public DependencyObject Instance { get; set; } // 실제 컨트롤 인스턴스를 저장하는 속성

        public ControlInfo()
        {
            Children = new List<ControlInfo>();
        }
    }

    public class DetailInfo
    { 
        public string Name { get; set; }
        public object Content { get; set; }
        public FrameworkElement Instance { get; internal set; }
    }


}
