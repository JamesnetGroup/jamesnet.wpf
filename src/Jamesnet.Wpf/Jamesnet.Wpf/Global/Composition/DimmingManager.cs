using Jamesnet.Wpf.Controls;
using System.Windows;

namespace Jamesnet.Wpf.Global.Composition
{
    public class DimmingManager
    {
        public DimmingManager()
        {
        }

        public void Dimming(bool isDimming)
        {
            if (Application.Current.MainWindow is DarkThemeWindow window)
            {
                window.Dimming = isDimming;
            }
        }
    }
}

