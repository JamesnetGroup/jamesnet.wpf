using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace LolButton.Support.UI.Units
{
    public class PlayButton : ToggleButton
    {
        static PlayButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlayButton), new FrameworkPropertyMetadata(typeof(PlayButton)));
        }
    }
}
