namespace WebApi.Core.Events
{
    public class PageSourceCreated
    {
        public int PageSourceId { get; }

        public PageSourceCreated( int pageSourceId )
        {
            PageSourceId = pageSourceId;
        }
    }
}
