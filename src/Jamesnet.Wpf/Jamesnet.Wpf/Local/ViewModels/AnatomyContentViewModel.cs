using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Local.Models;
using Jamesnet.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Jamesnet.Wpf.Local.ViewModels
{
    internal partial class AnatomyContentViewModel : ObservableBase, IViewLoadable
    {
        public void OnLoaded(IViewable view)
        {
            //List<DependencyObject> allChildren = new List<DependencyObject>();
            //if (anatomyItem.Instance is DependencyObject instance)
            //{
            //    allChildren.Add(instance); // 여기서 인스턴스 자기 자신을 추가합니다.
            //}
            //allChildren.AddRange(GetAllChildren(anatomyItem.Instance));

            ////DetailList detailList = new DetailList();
            ////uniform.Columns = 3;
            ////uniform.Background = Brushes.Black;




            ////detailList.ItemsSource = source1;
            ////detailList.SelectionChanged += DetailList_SelectionChanged;
            ////Grid.SetColumn(detailList, 2);
            ////grid.Children.Add(detailList);
        }
    }
}
