using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Jamesnet.Wpf.Controls
{
    public static class AnimationExtensions
    {
        public static readonly DependencyProperty AnimatedBackgroundProperty =
            DependencyProperty.RegisterAttached(
                "AnimatedBackground",
                typeof(Brush),
                typeof(AnimationExtensions),
                new PropertyMetadata(null, OnAnimatedBackgroundChanged));

        public static void SetAnimatedBackground(UIElement element, Brush value)
        {
            element.SetValue(AnimatedBackgroundProperty, value);
        }

        public static Brush GetAnimatedBackground(UIElement element)
        {
            return (Brush)element.GetValue(AnimatedBackgroundProperty);
        }

        public static readonly DependencyProperty AnimatedForegroundProperty =
            DependencyProperty.RegisterAttached(
                "AnimatedForeground",
                typeof(Brush),
                typeof(AnimationExtensions),
                new PropertyMetadata(null, OnAnimatedForegroundChanged));

        public static void SetAnimatedForeground(UIElement element, Brush value)
        {
            element.SetValue(AnimatedForegroundProperty, value);
        }

        public static Brush GetAnimatedForeground(UIElement element)
        {
            return (Brush)element.GetValue(AnimatedForegroundProperty);
        }

        private static void OnAnimatedBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AnimateColor(d, e.NewValue as SolidColorBrush, Control.BackgroundProperty);
        }

        private static void OnAnimatedForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AnimateColor(d, e.NewValue as SolidColorBrush, Control.ForegroundProperty);
        }

        public static readonly DependencyProperty AnimatedBorderBrushProperty =
            DependencyProperty.RegisterAttached(
                "AnimatedBorderBrush",
                typeof(Brush),
                typeof(AnimationExtensions),
                new PropertyMetadata(null, OnAnimatedBorderBrushChanged));

        public static void SetAnimatedBorderBrush(UIElement element, Brush value)
        {
            element.SetValue(AnimatedBorderBrushProperty, value);
        }

        public static Brush GetAnimatedBorderBrush(UIElement element)
        {
            return (Brush)element.GetValue(AnimatedBorderBrushProperty);
        }

        private static void OnAnimatedBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Border border)
            {
                AnimateColor(border, e.NewValue as SolidColorBrush, Border.BorderBrushProperty);
            }
        }

        public static readonly DependencyProperty AnimatedFillProperty =
            DependencyProperty.RegisterAttached(
                "AnimatedFill",
                typeof(Brush),
                typeof(AnimationExtensions),
                new PropertyMetadata(null, OnAnimatedFillChanged));

        public static void SetAnimatedFill(UIElement element, Brush value)
        {
            element.SetValue(AnimatedFillProperty, value);
        }

        public static Brush GetAnimatedFill(UIElement element)
        {
            return (Brush)element.GetValue(AnimatedFillProperty);
        }

        private static void OnAnimatedFillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Shape shape)
            {
                AnimateColor(shape, e.NewValue as SolidColorBrush, Shape.FillProperty);
            }
        }

        private static void AnimateColor(DependencyObject target, SolidColorBrush newBrush, DependencyProperty property)
        {
            if (target != null && newBrush != null)
            {
                var currentBrush = target.GetValue(property) as SolidColorBrush ?? new SolidColorBrush();

                var animation = new ColorAnimation
                {
                    From = currentBrush.Color,
                    To = newBrush.Color,
                    Duration = TimeSpan.FromSeconds(1),
                    EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                };

                var animatedBrush = new SolidColorBrush(currentBrush.Color);
                target.SetValue(property, animatedBrush);
                animatedBrush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
            }
        }
    }
}