using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Local.Helpers;
using Jamesnet.Wpf.Local.Models;
using Jamesnet.Wpf.Mvvm;
using System;
using System.Windows.Controls;

namespace Jamesnet.Wpf.Local.ViewModels
{
    internal class AnatomyAnalyzerViewModel : ObservableBase, IViewLoadable
    {
        private readonly AnatomyService _anatomyService;

        public StackPanel Instance { get; set; }

        public AnatomyAnalyzerViewModel(AnatomyService anatomyService) 
        {
            Instance = new();
            _anatomyService = anatomyService;

            _anatomyService.AnatomyControlChanged += _anatomyService_AnatomyControlChanged;
        }

        public void OnLoaded(IViewable view)
        {

        }

        private void _anatomyService_AnatomyControlChanged(object sender, AnatomyControlChangedEventArgs e)
        {
            foreach (Type item in e.Controls)
            {
                if (item.IsSubclassOf(typeof(Control)))
                {
                    Control control = (Control)Activator.CreateInstance(item);
                    Instance.Children.Add(control); 
                }
            }
        }
    }
}
