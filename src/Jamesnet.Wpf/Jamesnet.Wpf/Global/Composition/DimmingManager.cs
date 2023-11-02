using Jamesnet.Wpf.Controls;
using System.Windows;

namespace Jamesnet.Wpf.Global.Composition
{
    public class DimmingManager
    {
        public DimmingManager()
        {
            // TODO: ObservableWindow 폐기 및 DimmingManager 활용 검토바랍니다.
            // 함께: DataTrigger 폐기 및 Trigger로 대체
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

