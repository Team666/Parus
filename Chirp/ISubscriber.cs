namespace Chirp
{
    public interface ISubscriber<in T> where T : IMessage
    {
        void Receive(T message);
    }
}