using Jamesnet.Wpf.Mvvm;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Jamesnet.Wpf.Controls
{


    public class DarkThemeWindow : JamesWindow
    {
        public static readonly DependencyProperty PopupOpenProperty;
        public static readonly DependencyProperty TitleHeaderBackgroundProperty;
        public static readonly DependencyProperty CloseCommandProperty;
        public static readonly new DependencyProperty TitleProperty;
        public new object Title { get => GetValue (TitleProperty); set => SetValue (TitleProperty, value); }
        public ICommand CloseCommand { get => (ICommand)GetValue (CloseCommandProperty); set => SetValue (CloseCommandProperty, value); }
        public Brush TitleHeaderBackground { get => (Brush)GetValue (TitleHeaderBackgroundProperty); set => SetValue (TitleHeaderBackgroundProperty, value); }

        #region Dimming
        public static readonly DependencyProperty DimmingProperty;
        public static readonly DependencyProperty DimmingColorProperty;
        public static readonly DependencyProperty DimmingOpacityProperty;
        public bool Dimming { get => (bool)GetValue (DimmingProperty); set => SetValue (DimmingProperty, value); }
        public Brush DimmingColor { get => (Brush)GetValue (DimmingColorProperty); set => SetValue (DimmingColorProperty, value); }
        public double DimmingOpacity { get => (double)GetValue (DimmingOpacityProperty); set => SetValue (DimmingOpacityProperty, value); }
        #endregion



        private MaximizeButton maximBtn;
        static DarkThemeWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata (typeof (DarkThemeWindow), new FrameworkPropertyMetadata (typeof (DarkThemeWindow)));
            CloseCommandProperty = DependencyProperty.Register (nameof (CloseCommand), typeof (ICommand), typeof (DarkThemeWindow), new PropertyMetadata (null));
            TitleProperty = DependencyProperty.Register (nameof (Title), typeof (object), typeof (DarkThemeWindow), new UIPropertyMetadata (null));
            TitleHeaderBackgroundProperty = DependencyProperty.Register (nameof (TitleHeaderBackground), typeof (Brush), typeof (DarkThemeWindow), new PropertyMetadata (new SolidColorBrush ((Color)ColorConverter.ConvertFromString ("#252525"))));
            DimmingProperty = DependencyProperty.Register (nameof (Dimming), typeof (bool), typeof (DarkThemeWindow), new PropertyMetadata (false));
            DimmingColorProperty = DependencyProperty.Register (nameof (DimmingColor), typeof (Brush), typeof (DarkThemeWindow), new PropertyMetadata (new SolidColorBrush ((Color)ColorConverter.ConvertFromString ("#141414"))));
            DimmingOpacityProperty = DependencyProperty.Register (nameof (DimmingOpacity), typeof (double), typeof (DarkThemeWindow), new PropertyMetadata (0.8));
        }

        public DarkThemeWindow()
        {
            this.StateChanged += (s, e) =>
            {
                maximBtn.IsMaximize = !maximBtn.IsMaximize;
            };
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged (e);
            if (e.Property.Name == "DataContext")
            {
                if (DataContext?.GetType ().BaseType.Name == "ObservableWindow")
                {
                    this.SetBinding (DimmingProperty, nameof (Dimming));
                }
            }
        }
        public override void OnApplyTemplate()
        {
            if (GetTemplateChild ("PART_CloseButton") is CloseButton btn)
            {
                btn.Click += (s, e) => WindowClose ();
            }

            if (GetTemplateChild ("PART_MinButton") is MinimizeButton minbtn)
            {
                minbtn.Click += (s, e) => WindowState = WindowState.Minimized;
            }

            if (GetTemplateChild ("PART_MaxButton") is MaximizeButton maxbtn)
            {
                maximBtn = maxbtn;
                maxbtn.Click += (s, e) =>
                {
                    if (maxbtn.IsMaximize)
                    {
                        this.WindowState = WindowState.Normal;
                    }
                    else
                    {
                        this.WindowState = WindowState.Maximized;
                    }
                  
                };
            }
            if (GetTemplateChild ("PART_DragBar") is DraggableBar bar)
            {
                bar.MouseDown += WindowDragMove;
            }
            maximBtn.IsMaximize = this.WindowState == WindowState.Maximized;
        }
        private void WindowClose()
        {
            if (CloseCommand == null)
            {
                Close ();
            }
            else
            {
                CloseCommand.Execute (this);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed (e);
        }

        private void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                GetWindow (this).DragMove ();
            }
        }
    }
}