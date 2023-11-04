using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jamesnet.Wpf.Controls
{
    public enum ImageType
    {
        None,
        AppStore,
        Arsenal,
        Benz,
        Bmw,
        Chelsea,
        CrystalPalace,
        Disney,
        DisneyPlus,
        Everton,
        Honda,
        Hyundai,
        LeicesterCity,
        ManchesterCity,
        ManchesterUnited,
        NewCastle,
        Porsche,
        Prime,
        QQ,
        SouthHampton,
        Spotify,
        Sunderland,
        SwanseaCity,
        Tesla,
        Tinder,
        Tottenham,
        WestBromwitchAlbion,
        USA,
        KOR,
        CHN,
        JPN,
        VNM,
        ESP
    }

    public enum IconType
    {
        Account,
        AccountGroup,
        AccountMultipleOutline,
        Apple,
        ArrowAll,
        ArrowDownBox,
        ArrowLeftBold,
        ArrowRightBold,
        ArrowUpBold,
        BellOutline,
        CalendarMonth,
        CardMultiple,
        CardMultipleOutline,
        Cash,
        Cash100,
        CashMulti,
        Check,
        Checkbold,
        Menu,
        CheckCircle,
        CheckDecagram,
        ChevronDown,
        ChevronRight,
        Close,
        Cloud,
        CogRefreshOutline,
        Comment,
        CommentOutline,
        ConsoleLine,
        Contentpaste,
        Creditcardchip,
        CreditcardchipOutline,
        Crop,
        CursorPointer,
        Database,
        DatabasePlus,
        Delete,
        DesktopClassic,
        Domain,
        DotsHorizontal,
        DotsHorizontalCircle,
        Email,
        EmailOutline,
        EyeCircle,
        EyedropperVariant,
        Facebook,
        File,
        FileCheck,
        FileImage,
        FilePdf,
        FileWord,
        FileZip,
        Folder,
        FolderOpen,
        FolderOpenOutline,
        FolderOutline,
        FolderRable,
        Google,
        GoogleTranslate,
        Grid,
        Harddisk,
        Heart,
        HeartOutline,
        History,
        Home,
        HomeCircle,
        HomeCircleOutline,
        HomeOutline,
        Image,
        Instagram,
        Link,
        LinkBox,
        Linkedin,
        LinkVariant,
        MapMaker,
        MapMarkerOutline,
        Maximize,
        Memory,
        Microsoft,
        CalendarBlankOutline,
        MicrosoftVisualStudio,
        MicrosoftWindows,
        Minimize,
        MonitorShimmer,
        MoveOpenPlay,
        Netflix,
        None,
        Palette,
        Pin,
        Plus,
        PlusBox,
        PokerChip,
        Resize,
        Restore,
        SelectAll,
        Star,
        TextBox,
        Twitter,
        Web,
        Youtube,
        ChartBubble,
        ChartPie,
        ClipboardCheck,
        FormatListBulleted,
        Cog,
        AccountBox,
        CogOutline,
        Security,
        ShieldLock,
        Timetable,
        ClipboardTextClock,
        Information,
        InformationOutline,
        AccountCircle,
        FilterVariant,
        Ruler,
        ArrowLeft,
        ArrowRight,
        ArrowLeftThin,
        ArrowRightThin,
        KeyboardBackspace,
        ButtonCursor,
        Import,
        Export,
        Trash,
        TrashOutline,
        DeleteEmpty,
        Magnify,
        ViewColumn,
        ViewGrid,
        SkipPrevious,
        SkipNext,
        CardSuitClub,
        CardSuitHeart,
        CardSuitSpade,
        CardSuitDiamond,
        ViewAgenda,
        ViewCompact,
        WeatherNight,
        WhiteBalanceSunny,
        SwapHorizontal
    }

    public enum IconMode
    {
        None,
        Icon,
        Image,
    }

    public class JamesIcon : ContentControl
    {
        private Image _image;

        public static DependencyProperty ModeProperty = DependencyProperty.Register("Mode", typeof(IconMode), typeof(JamesIcon), new PropertyMetadata(IconMode.None));
        public static DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(IconType), typeof(JamesIcon), new PropertyMetadata(IconType.None, IconPropertyChanged));
        public static DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageType), typeof(JamesIcon), new PropertyMetadata(ImageType.None, ImagePropertyChanged));
        public static DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(JamesIcon), new PropertyMetadata(Brushes.Silver));
        public static DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(Geometry), typeof(JamesIcon), new PropertyMetadata(null));
        public static DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(JamesIcon), new PropertyMetadata(null));

        public IconMode Mode
        {
            get => (IconMode)GetValue(ModeProperty);
            set => SetValue(ModeProperty, value);
        }

        public IconType Icon
        {
            get => (IconType)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public ImageType Image
        {
            get => (ImageType)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public Brush Fill
        {
            get => (Brush)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        public Geometry Data
        {
            get => (Geometry)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        private static void IconPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            JamesIcon jamesIcon = (JamesIcon)d;
            string geometryData = Design.Geometries.GeometryConverter.GetData(jamesIcon.Icon.ToString());

            jamesIcon.Data = Geometry.Parse(geometryData);
            jamesIcon.Mode = IconMode.Icon;
        }

        private static void ImagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            JamesIcon jamesIcon = (JamesIcon)d;
            string base64 = Design.Images.ImageConverter.GetData(jamesIcon.Image.ToString());

            byte[] binaryData = Convert.FromBase64String(base64);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();

            jamesIcon.Source = bi;
            jamesIcon.Mode = IconMode.Image;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        static JamesIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JamesIcon), new FrameworkPropertyMetadata(typeof(JamesIcon)));
        }
    }
}
