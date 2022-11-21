using Jamesnet.Design.Global.Models;
using Jamesnet.Design.Global.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamesnet.Design.Global.Converters
{
    public partial class IconData
    {
        public static string AlphaBBox = IconDataHelpers.GetData("alpha_b_box");
        public static string AlphaGBox = IconDataHelpers.GetData("alpha_g_box");
        public static string AlphaRBox = IconDataHelpers.GetData("alpha_r_box");
    }
}
