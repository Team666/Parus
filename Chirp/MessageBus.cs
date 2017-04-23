using System.Collections.Generic;

namespace Chirp
{
    public static class MessageBusOf<TMessage> where TMessage : IMessage
    {
        private static readonly List<ISubscriber<TMessage>> _subscribers;

        static MessageBusOf()
        {
            _subscribers = new List<ISubscriber<TMessage>>();
        }

        public static void AcceptSubscriber(ISubscriber<TMessage> subscriber)// where T : ISubscriber<TMessage>// where TU : TMessage
        {
            _subscribers.Add(subscriber);
        }

        public static void Receive(TMessage message)
        {
            _subscribers.ForEach(item => item.Receive(message));
        }
    }
}
