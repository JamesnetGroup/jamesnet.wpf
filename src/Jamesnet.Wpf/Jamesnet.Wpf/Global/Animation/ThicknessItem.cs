using Jamesnet.Wpf.Animation;
using System.Windows;
using System.Windows.Media.Animation;

namespace Jamesnet.Wpf.Controls
{
    public class ThickItem : ThicknessAnimation
    {
        #region TargetName

        public static readonly DependencyProperty TargetNameProperty = DependencyProperty.Register(
            "TargetName",
            typeof(string),
            typeof(ThickItem),
            new PropertyMetadata(null, OnTargetNameChanged)
        );

        public string TargetName
        {
            get { return (string)GetValue(TargetNameProperty); }
            set { SetValue(TargetNameProperty, value); }
        }
        #endregion

        #region Property

        public static readonly DependencyProperty PropertyProperty = DependencyProperty.Register(
            "Property",
            typeof(PropertyPath),
            typeof(ThickItem),
            new PropertyMetadata(null, OnPropertyChanged)
        );

        public PropertyPath Property
        {
            get { return (PropertyPath)GetValue(PropertyProperty); }
            set { SetValue(PropertyProperty, value); }
        }
        #endregion

        private static void OnTargetNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = (ThickItem)d;
            var targetName = (string)e.NewValue;

            Storyboard.SetTargetName(item, targetName);
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = (ThickItem)d;
            var propertyPath = (PropertyPath)e.NewValue;

            Storyboard.SetTargetProperty(item, propertyPath);
        }

        #region Mode

        public static readonly DependencyProperty ModeProperty = DependencyProperty.Register (
            "Mode",
            typeof (EasingFunctionBaseMode),
            typeof (ColorItem),
            new PropertyMetadata (EasingFunctionBaseMode.CubicEaseIn, OnEasingModeChanged)
        );

        public EasingFunctionBaseMode Mode
        {
            get { return (EasingFunctionBaseMode)GetValue (ModeProperty); }
            set { SetValue (ModeProperty, value); }
        }
        #endregion

        private static void OnEasingModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = (ThickItem)d;
            var easingMode = (EasingFunctionBaseMode)e.NewValue;

            if (item.EasingFunction is CubicEase cubicEase)
            {
                cubicEase.EasingMode = GetMode (easingMode);
                return;
            }

            item.EasingFunction = GetEasingFunc (easingMode);
        }

        private static IEasingFunction GetEasingFunc(EasingFunctionBaseMode mode)
        {
            EasingMode easingMode = GetMode (mode);
            EasingFunctionBase easingFunctionBase = GetFunctonBase (mode);

            easingFunctionBase.EasingMode = easingMode;

            return (IEasingFunction)easingFunctionBase;
        }

        private static EasingFunctionBase GetFunctonBase(EasingFunctionBaseMode mode)
        {
            var enumString = mode.ToString ().Replace ("EaseInOut", "").Replace ("EaseIn", "").Replace ("EaseOut", "");

            if (enumString == "Back")
                return new BackEase ();
            if (enumString == "Bounce")
                return new BounceEase ();
            if (enumString == "Circle")
                return new CircleEase ();
            if (enumString == "Cubic")
                return new CubicEase ();
            if (enumString == "Elastic")
                return new ElasticEase ();
            if (enumString == "Exponential")
                return new ExponentialEase ();
            if (enumString == "Power")
                return new PowerEase ();
            if (enumString == "Quadratic")
                return new QuadraticEase ();
            if (enumString == "Quartic")
                return new QuarticEase ();
            if (enumString == "Quintic")
                return new QuinticEase ();
            if (enumString == "Sine")
                return new SineEase ();

            return null;
        }

        private static EasingMode GetMode(EasingFunctionBaseMode mode)
        {
            var enumString = mode.ToString ();

            if (enumString.Contains ("EaseInOut"))
                return EasingMode.EaseInOut;
            else if (enumString.Contains ("EaseIn"))
                return EasingMode.EaseIn;

            return EasingMode.EaseOut;
        }
    }


}
