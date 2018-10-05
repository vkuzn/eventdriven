using WebApi.Core.Events;

namespace WebApi.Core
{
    public interface IEventsDispatcher<T>
    {
        void Publish( T msg );
    }

    public interface IEventsDispatcher :
        IEventsDispatcher<ResourceCreated>,
        IEventsDispatcher<PageSourceCreated>,
        IEventsDispatcher<StatusCodeChecked>
    { }
}
