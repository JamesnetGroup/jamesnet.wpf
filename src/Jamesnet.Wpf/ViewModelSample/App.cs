using Jamesnet.Wpf.Controls;
using System.Windows;
using ViewModelSample.Forms.UI.Views;

namespace ViewModelSample
{
        public class App : JamesApplication
        {
                protected override Window CreateShell()
                {
                        return new MainWindow();
                }
        }
}
