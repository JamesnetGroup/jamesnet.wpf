using System.Windows;

namespace Jamesnet.Wpf.Controls
{
    public class AnatomyAnalyzer : DarkThemeWindow
    {
        static AnatomyAnalyzer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnatomyAnalyzer), new FrameworkPropertyMetadata(typeof(AnatomyAnalyzer)));
        }
    }
}
