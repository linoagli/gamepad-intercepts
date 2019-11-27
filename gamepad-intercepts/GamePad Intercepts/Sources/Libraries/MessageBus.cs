using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBus
{
    class Bus
    {
        private static Bus instance;
        public static Bus Instance
        {
            get
            {
                if (instance == null) instance = new Bus();

                return instance;
            }
        }

        private readonly Dictionary<Type, List<Subscription>> routes = new Dictionary<Type, List<Subscription>>();

        private Bus()
        {
            //
        }

        public void Subscribe<T>(object subscriber, Action<T> handler)
        {
            Type type = typeof(T);
            List<Subscription> subscriptions;

            if (!routes.TryGetValue(type, out subscriptions))
            {
                subscriptions = new List<Subscription>();
                routes.Add(type, subscriptions);
            }

            if (!subscriptions.Any(i => i.SubscriberReference.Target == subscriber))
            {
                subscriptions.Add(new Subscription
                {
                    SubscriberReference = new WeakReference(subscriber),
                    Handler = (object o) => handler.Invoke((T)o)
                });
            }
        }

        public void Unsubscribe(object subscriber)
        {
            foreach (var subscriptions in routes.Values)
            {
                subscriptions.RemoveAll(i => i.SubscriberReference.Target == subscriber);
            }            
        }

        public void Publish(object message)
        {
            var subscriptions = GetSubscriptions(message.GetType());

            if (!subscriptions.Any()) return;

            subscriptions.RemoveAll(i => !i.SubscriberReference.IsAlive);

            foreach (var subscription in subscriptions) PushMessage(message, subscription);
        }

        private List<Subscription> GetSubscriptions(Type type)
        {
            return routes
                .Where(i => i.Key.IsAssignableFrom(type))
                .SelectMany(i => i.Value)
                .ToList();
        }

        private void PushMessage(object message, Subscription subscription)
        {
            try
            {
                subscription.Handler.Invoke(message);
            }
            catch
            {
                // Do nothing...
            }
        }

        private class Subscription
        {
            public WeakReference SubscriberReference { get; set; }
            public Action<object> Handler { get; set; }
        }
    }
}
