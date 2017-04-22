using System;

namespace Chirp
{
    public interface IEvent<TMessage>
    {
        void Send(object sender, TMessage value);
        void Subscribe(Action<object, TMessage> action);
    }
}