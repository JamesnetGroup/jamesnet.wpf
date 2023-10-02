using Jamesnet.Wpf.Local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamesnet.Wpf.Local.Helpers
{
    internal class AnatomyService
    {
        public event EventHandler<AnatomyControlChangedEventArgs> AnatomyControlChanged;

        internal void Add(AnatomyCollection items)
        {
            var args = new AnatomyControlChangedEventArgs();
            args.Controls = items;
            AnatomyControlChanged.Invoke(this, args);
        }
    }
}
