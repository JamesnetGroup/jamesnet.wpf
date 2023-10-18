using Jamesnet.Wpf.Event;
using Jamesnet.Wpf.Global.Event;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Jamesnet.Wpf.Controls;

public class DarkThemeWindow : JamesWindow
{
    public static readonly DependencyProperty PopupOpenProperty;
    public static readonly DependencyProperty TitleBarColorProperty;
    public static readonly DependencyProperty CloseCommandProperty ;
    public static readonly new DependencyProperty TitleProperty;

    public new object Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public ICommand CloseCommand
    {
        get => (ICommand)GetValue(CloseCommandProperty);
        set => SetValue(CloseCommandProperty, value);
    }
    public Brush TitleBarColor
    {
        get => (Brush)GetValue (TitleBarColorProperty);
        set => SetValue (TitleBarColorProperty, value);
    }
    private MaximizeButton maximBtn;
    static DarkThemeWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkThemeWindow), new FrameworkPropertyMetadata(typeof(DarkThemeWindow)));
        CloseCommandProperty = DependencyProperty.Register (nameof (CloseCommand), typeof (ICommand), typeof (DarkThemeWindow), new PropertyMetadata (null));
        TitleProperty = DependencyProperty.Register (nameof (Title), typeof (object), typeof (DarkThemeWindow), new UIPropertyMetadata (null));
        TitleBarColorProperty = DependencyProperty.Register (nameof (TitleBarColor), typeof (Brush), typeof (DarkThemeWindow), new PropertyMetadata (new SolidColorBrush ((Color)ColorConverter.ConvertFromString ("#252525"))));        
    }

    public DarkThemeWindow()
    {
        if (JamesApplication.Current == null)
            return;

        JamesApplication.GetService<IEventHub>().Subscribe<PopupPubsub, bool>(e=>
        {
            if(e == true)
            {

                this.grd.Visibility = Visibility.Visible;
                return;
            }
            this.grd.Visibility = Visibility.Collapsed;
        });
    }

    Grid grd;
    public override void OnApplyTemplate()
    {
        if (GetTemplateChild("PART_CloseButton") is CloseButton btn)
        {
            btn.Click += (s, e) => WindowClose();
        }

        if (GetTemplateChild("PART_MinButton") is MinimizeButton minbtn)
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
                maxbtn.IsMaximize = !maxbtn.IsMaximize;
            };
        }
        if (GetTemplateChild("PART_DragBar") is DraggableBar bar)
        {
            bar.MouseDown += WindowDragMove;
        }

        if(GetTemplateChild ("PART_GRD") is Grid grd)
        {
            this.grd = grd;
        }
        maximBtn.IsMaximize = this.WindowState == WindowState.Maximized;
    }

    private void WindowClose()
    {
        if (CloseCommand == null)
        {
            Close();
        }
        else
        {
            CloseCommand.Execute(this);
        }
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
    }

    private void WindowDragMove(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            GetWindow(this).DragMove();
        }
    }
}