using Jamesnet.Wpf.Controls;
using LolButton.Support.UI.Units;
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
        protected override Window CreateShell()
        {
            var button = new PlayButton();
            button.Loaded += Button_Loaded;


            Window window = new DarkThemeWindow()
                .AddChild(button)
                .CenterAlignContent()
                .ApplyThemeColors("#000000", "#000000", "#FFFFFF");

            return window;
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            var allChildren = GetAllChildren(sender as DependencyObject);

            Window window = new DarkThemeWindow();
            window.Width = 600;
            window.Height = 800;
            window.Title = "VisualBrush Preview";

            UniformGrid stackPanel = new UniformGrid();
            stackPanel.Columns = 3;
            window.Content = stackPanel;

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

                    stackPanel.Children.Add(rect);
                }
            }

            window.Show();
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

    }
}
