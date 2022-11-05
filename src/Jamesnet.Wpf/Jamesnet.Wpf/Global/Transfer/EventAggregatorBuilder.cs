using Prism.Events;

namespace Jamesnet.Wpf.Global.Evemt
{
    public class EventAggregatorBuilder
    {
        public static IEventHub Get(IEventAggregator ea)
        {
            return new EventAggregatorHub(ea);
        }
    }
}
