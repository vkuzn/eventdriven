namespace WebApi.Core
{
    public interface IEventListener<TEvent>
    {
        void Handle( TEvent msg, IEventsDispatcher eventsDispatcher );
    }
}
