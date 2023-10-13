using System;
using System.Diagnostics;

using Prism.Events;

namespace Jamesnet.Wpf.Global.Event
{
    internal class EventAggregatorHub : IEventHub
    {
        private IEventAggregator _ea;

        internal EventAggregatorHub(IEventAggregator ea)
        {
            Debug.WriteLine("new ea");
            _ea = ea;
        }

        public Action<StackTrace> Publising { get; set; }

        public void Publish<T1, T2>(T2 value) where T1 : PubSubEvent<T2>, new()
        {
            StackTrace stackTrace = new StackTrace();
            // Get calling method name
            Debug.WriteLine(stackTrace.GetFrame(1).GetMethod().Name);

            Publising?.Invoke(stackTrace);
            _ea.GetEvent<T1>().Publish(value);
        }

        public void Subscribe<T1, T2>(Action<T2> action) where T1 : PubSubEvent<T2>, new()
        {
            _ea.GetEvent<T1>().Subscribe(action);
        }
    }
}
