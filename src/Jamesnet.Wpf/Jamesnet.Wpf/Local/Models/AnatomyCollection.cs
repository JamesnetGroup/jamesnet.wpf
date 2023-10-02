using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamesnet.Wpf.Local.Models
{
    public class AnatomyCollection : List<Type>
    {
        
        public void Add<T>()
        {
            Add(typeof(T));
        }
    }
}
