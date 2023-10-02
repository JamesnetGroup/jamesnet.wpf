using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Local.Models;
using System.Windows;
using System.Windows.Controls;

namespace AnatomyAnalyzerTestApp
{
    internal class App : AnatomyApplication
    {
        protected override void RegisterControls(AnatomyCollection items)
        {
            items.Add<Button>();
            items.Add<Slider>();
            items.Add<ComboBox>();
        }
    }
}
