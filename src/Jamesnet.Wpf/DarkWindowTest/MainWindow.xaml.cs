using Jamesnet.Wpf.Controls;

namespace DarkWindowTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DarkThemeWindow
    {
        public MainWindow()
        {
            InitializeComponent ();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DataContext = new MainContentViewModel ();
        }
    }
}
