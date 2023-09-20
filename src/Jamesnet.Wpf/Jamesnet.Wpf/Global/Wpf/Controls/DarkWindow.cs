using System;
using System.Windows;
using System.Windows.Input;

namespace Jamesnet.Wpf.Controls;

public class DarkWindow : JamesWindow
{
    public static readonly DependencyProperty CloseCommandProperty =
        DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(DarkWindow), new PropertyMetadata(null));

    public static readonly new DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(object), typeof(DarkWindow), new UIPropertyMetadata(null));

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

    private MaximizeButton maximBtn;
    static DarkWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow), new FrameworkPropertyMetadata(typeof(DarkWindow)));
    }

    public DarkWindow()
    {

    }

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