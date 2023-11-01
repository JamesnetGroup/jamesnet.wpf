using Jamesnet.Wpf.Controls;
using System.Windows;

namespace Jamesnet.Wpf.Global.Composition
{
    public abstract class DimmingManager
    {
        public string ThemePath { get; }
        public string DefaultLocale { get; }
        public string DefaultThemeName { get; }
        public string LocalePath { get; }

        protected abstract string FetchThemePath();
        protected abstract string DetermineDefaultThemeName();

        protected abstract string FetchLocalePath();
        protected abstract string DetermineDefaultLocale();

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

