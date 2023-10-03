using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Local.Helpers;
using Jamesnet.Wpf.Local.Models;
using Jamesnet.Wpf.Mvvm;
using Jamesnet.Wpf.UI.Units;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Jamesnet.Wpf.Local.ViewModels
{
    internal partial class AnatomyAnalyzerViewModel : ObservableBase, IViewLoadable
    {
        private readonly AnatomyService _anatomyService;
        private readonly IContainerRegistry _containerRegistry;
        private readonly IContainerProvider _containerProvider;
        private readonly IRegionManager _regionManager;

        public Dictionary<Type, object> Instances { get; set; }

        public ObservableCollection<AnatomyItem> Controls { get; set; }

        public AnatomyAnalyzerViewModel(AnatomyService anatomyService, IContainerProvider containerProvider, IRegionManager regionManager) 
        {
            Instances = new();
            Controls = new();
            _anatomyService = anatomyService;
            _containerProvider = containerProvider;
            _regionManager = regionManager;
            _anatomyService.AnatomyControlChanged += _anatomyService_AnatomyControlChanged;
        }

        public void OnLoaded(IViewable view)
        {

        }

        private void _anatomyService_AnatomyControlChanged(object sender, AnatomyControlChangedEventArgs e)
        {
            foreach (Type item in e.Controls)
            {
                if (item.IsSubclassOf(typeof(Control)))
                {
                    //Control control = (Control)Activator.CreateInstance(item);
                    //Instance.Children.Add(control);

                    AnatomyItem anatomyItem = new();
                    anatomyItem.Name = item.Name;
                    anatomyItem.Type = item;
                    anatomyItem.IconType = IconType.ButtonCursor;
                    anatomyItem.Items = new();
                    Controls.Add(anatomyItem);
                }
            }
        }

        [RelayCommand]
        private void TreeItemSelected(AnatomyItem anatomyItem)
        {
            ImportContent("AnatomyObjectRegion", anatomyItem);

            List<DependencyObject> allChildren = new List<DependencyObject>();
            if (anatomyItem.Instance is DependencyObject instance)
            {
                allChildren.Add(instance); // 여기서 인스턴스 자기 자신을 추가합니다.
            }
            allChildren.AddRange(GetAllChildren(anatomyItem.Instance));

            //DetailList detailList = new DetailList();
            //uniform.Columns = 3;
            //uniform.Background = Brushes.Black;

            anatomyItem.Items.Clear();

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

                    var detailInfo = new DetailInfo();
                    detailInfo.Content = rect;
                    detailInfo.Name = element.GetType().Name;
                    detailInfo.Instance = element;
                    anatomyItem.Items.Add(detailInfo);
                }
            }



            //detailList.ItemsSource = source1;
            //detailList.SelectionChanged += DetailList_SelectionChanged;
            //Grid.SetColumn(detailList, 2);
            //grid.Children.Add(detailList);
        }

        private void ImportContent(string regionName, AnatomyItem item)
        {
            IRegion region = _regionManager.Regions[regionName];
            object content = GetControl(item);

            if (!region.Views.Contains(content))
            {
                region.Add(content);
            }
            region.Activate(content);
        }

        private object GetControl(AnatomyItem item)
        {
            if (!Instances.ContainsKey(item.Type))
            {
                Control control = (Control)Activator.CreateInstance(item.Type);
                AnatomyPreview preview = new();
                preview.Content = control;
                preview.DataContext = item;
                Instances.Add(item.Type, preview);
            }
            return Instances[item.Type];
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


        List<AnatomyItem> source = new List<AnatomyItem>();

        void AddControl(object obj)
        {
            if (obj is DependencyObject dependencyObject)
            {
                AnatomyItem controlInfo = new AnatomyItem
                {
                    Name = obj.GetType().Name,
                    ControlType = obj.GetType(),
                    Instance = dependencyObject
                };

                AddChildControls(controlInfo, dependencyObject); // 자식 컨트롤들을 추가합니다.

                source.Add(controlInfo); // 루트 컨트롤만 source 리스트에 추가합니다.
            }
        }

        void AddChildControls(AnatomyItem parentControlInfo, DependencyObject parentDependencyObject)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parentDependencyObject);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parentDependencyObject, i);
                AnatomyItem childControlInfo = new AnatomyItem
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
}
