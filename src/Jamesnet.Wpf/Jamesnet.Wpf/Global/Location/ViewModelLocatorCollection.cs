using Prism.Mvvm;
using System.Collections.Generic;

namespace Jamesnet.Wpf.Global.Location
{
    public class ViewModelLocatorCollection : List<ViewModelLocatorItem>
    {
        public void Register<T1, T2>()
        {
            ViewModelLocationProvider.Register<T1, T2>();
            this.Add(new ViewModelLocatorItem(typeof(T1), typeof(T2)));
        }
    }
}
