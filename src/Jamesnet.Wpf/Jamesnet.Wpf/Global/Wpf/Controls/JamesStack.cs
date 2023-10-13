using System;
using System.Windows;
using System.Windows.Controls;

namespace Jamesnet.Wpf.Controls;
public class JamesStack : StackPanel
{
    public double ChildSpacing
    {
        get => (double)GetValue(ChildSpacingProperty);
        set => SetValue(ChildSpacingProperty, value);
    }

    public static readonly DependencyProperty ChildSpacingProperty =
        DependencyProperty.Register("ChildSpacing", typeof(double), typeof(JamesStack),
            new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsArrange));

    protected override Size MeasureOverride(Size availableSize)
    {
        double width = 0;
        double height = 0;
        double stackedWidth = 0;
        double stackedHeight = 0;

        foreach (UIElement child in InternalChildren)
        {
            if (child == null) continue;

            child.Measure(availableSize);

            Size childSize = child.DesiredSize;

            if (Orientation == Orientation.Vertical)
            {
                stackedHeight += childSize.Height + ChildSpacing;
                width = Math.Max(width, childSize.Width);
            }
            else
            {
                stackedWidth += childSize.Width + ChildSpacing;
                height = Math.Max(height, childSize.Height);
            }
        }

        if (InternalChildren.Count > 0)
        {
            if (Orientation == Orientation.Vertical)
                stackedHeight -= ChildSpacing;
            else
                stackedWidth -= ChildSpacing;
        }

        return Orientation == Orientation.Vertical
            ? new Size(width, stackedHeight)
            : new Size(stackedWidth, height);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        double offset = 0;
        foreach (UIElement child in InternalChildren)
        {
            if (child == null) continue;

            Size childSize = child.DesiredSize;

            if (Orientation == Orientation.Vertical)
            {
                child.Arrange(new Rect(0, offset, finalSize.Width, childSize.Height));
                offset += childSize.Height + ChildSpacing;
            }
            else
            {
                child.Arrange(new Rect(offset, 0, childSize.Width, finalSize.Height));
                offset += childSize.Width + ChildSpacing;
            }
        }

        if (InternalChildren.Count > 0)
            offset -= ChildSpacing;

        return Orientation == Orientation.Vertical
            ? new Size(finalSize.Width, offset)
            : new Size(offset, finalSize.Height);
    }
}
