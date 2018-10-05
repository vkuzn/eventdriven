using Microsoft.AspNetCore.Mvc;
using WebApi.Core;
using WebApi.Core.Events;

namespace WebApi.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsDispatcher _eventsDispatcher;

        public EventsController( IEventsDispatcher eventsDispatcher )
        {
            _eventsDispatcher = eventsDispatcher;
        }

        // GET api/events
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "ping";
        }

        // GET api/events/resource-created/5
        [HttpGet( "resource-created/{resourceId}" )]
        public string ResourceCreated( int resourceId )
        {
            _eventsDispatcher.Publish( new ResourceCreated( resourceId ) );
            return $"ResourceCreated({resourceId})";
        }

        // GET api/events/resource-created/5
        [HttpGet( "page-source-created/{pageSourceId}" )]
        public string PageSourceCreated( int pageSourceId )
        {
            _eventsDispatcher.Publish( new PageSourceCreated( pageSourceId ) );
            return $"PageSourceCreated({pageSourceId})";
        }

        // GET api/events/status-code-checked/5
        [HttpGet( "status-code-checked/{resourceId}" )]
        public string StatusCodeChecked( int resourceId )
        {
            _eventsDispatcher.Publish( new StatusCodeChecked( resourceId ) );
            return $"StatusCodeChecked({resourceId})";
        }
    }
}
