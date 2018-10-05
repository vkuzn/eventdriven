using System.Diagnostics;
using WebApi.Core.Events;

namespace WebApi.Core
{
    public class StatusCodeChecker : IEventListener<ResourceCreated>
    {
        public void Handle( ResourceCreated msg, IEventsDispatcher eventsDispatcher )
        {
            Debug.WriteLine( $"PagespeedChecker: handling ResourceCreated({msg.ResourceId})" );

            //TODO: сделать полезную работу

            eventsDispatcher.Publish( new StatusCodeChecked( msg.ResourceId ) );
        }
    }
}
