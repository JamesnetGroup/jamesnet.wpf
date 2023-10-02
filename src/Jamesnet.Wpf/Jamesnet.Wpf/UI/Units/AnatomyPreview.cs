using System.Windows;
using System.Windows.Controls;

namespace Jamesnet.Wpf.UI.Units
{
    public class AnatomyPreview : ContentControl
    {
        static AnatomyPreview()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnatomyPreview), new FrameworkPropertyMetadata(typeof(AnatomyPreview)));
        }
    }
}
