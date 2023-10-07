using AnatomyAnalyzerTestApp.UI.Units;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Local.Models;
using Jamesnet.Wpf.Models;
using System.Windows.Controls;

namespace AnatomyAnalyzerTestApp
{
    internal class App : AnatomyApplication
    {
        protected override void RegisterControls(AnatomyCollection items)
        {
            items.Add<PlayButton>();
            items.Add<Button>();
            items.Add<Slider>();
            items.Add<ComboBox>();
        }
    }
}
