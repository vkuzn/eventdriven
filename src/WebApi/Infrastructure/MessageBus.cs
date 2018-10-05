using System;
using WebApi.Core;
using WebApi.Core.Events;

namespace WebApi.Infrastructure
{
    public class MessageBus :
        IEventsDispatcher,
        ISubscribersRegistrator<ResourceCreated>,
        ISubscribersRegistrator<PageSourceCreated>,
        ISubscribersRegistrator<StatusCodeChecked>
    {
        private event EventHandler<ResourceCreated> _resourceCreated;
        private event EventHandler<PageSourceCreated> _pageSourceCreated;
        private event EventHandler<StatusCodeChecked> _statusCodeChecked;

        public void Publish( ResourceCreated msg )
        {
            _resourceCreated?.Invoke( this, msg );
        }

        public void Publish( PageSourceCreated msg )
        {
            _pageSourceCreated?.Invoke(this, msg);
        }

        public void Publish( StatusCodeChecked msg )
        {
            _statusCodeChecked.Invoke( this, msg );
        }

        public void Subscribe( IEventListener<ResourceCreated> listener )
        {
            _resourceCreated += ( sender, msg ) => listener.Handle( msg, this );
        }

        public void Subscribe( IEventListener<PageSourceCreated> listener )
        {
            _pageSourceCreated += ( sender, msg ) => listener.Handle( msg, this );
        }

        public void Subscribe( IEventListener<StatusCodeChecked> listener )
        {
            _statusCodeChecked += ( sender, msg ) => listener.Handle( msg, this );
        }
    }
}
