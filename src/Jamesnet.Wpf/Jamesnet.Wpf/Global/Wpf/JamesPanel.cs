using System.Windows;
using System.Windows.Controls;

namespace Jamesnet.Wpf.Controls
{
		public class JamesPanel : StackPanel
		{
				public double Spacing
				{
						get { return (double)GetValue (SpacingProperty); }
						set { SetValue (SpacingProperty, value); }
				}

				public static readonly DependencyProperty SpacingProperty =
					DependencyProperty.Register ("Spacing", typeof (double), typeof (JamesPanel), new PropertyMetadata (0.0));

				protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
				{
						base.OnPropertyChanged (e);

						PerformLayout ();
				}

				private void PerformLayout()
				{
						if (Spacing < 0)
								return;
						if (base.Children.Count <= 1)
								return;

						Thickness thick = Orientation == Orientation.Horizontal ? new Thickness (0, 0, Spacing, 0) : new Thickness (0, 0, 0, Spacing);

						int lastIdx = base.Children.Count - 1;
						int idx = 0;
						foreach (UIElement child in base.Children)
						{
								if (lastIdx == idx)
										break;
								child.SetValue (MarginProperty, thick);
								idx++;
						}
				}
		}
}
