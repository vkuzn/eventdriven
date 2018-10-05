using WebApi.Core;

namespace WebApi.Infrastructure
{
    public interface ISubscribersRegistrator<TEvent>
    {
        void Subscribe( IEventListener<TEvent> handler );
    }

    public static class ISubscribersRegistratorExtensions
    {
        public static void Subscribe<TEvent>( this ISubscribersRegistrator<TEvent> registrator, IEventListener<TEvent> listener )
        {
            registrator.Subscribe( listener );
        }
    }

}
