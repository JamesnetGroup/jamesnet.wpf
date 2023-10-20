#if NETFRAMEWORK
using WpfAutoGrid;

namespace Jamesnet.Wpf.Controls
{
    public class JamesGrid : AutoGrid
    {
        public JamesGrid()
        {
        }
    }
}
#else
using WpfAutoGrid;

namespace Jamesnet.Wpf.Controls;
public class JamesGrid : AutoGrid
{
    public JamesGrid()
    {
    }
}
#endif