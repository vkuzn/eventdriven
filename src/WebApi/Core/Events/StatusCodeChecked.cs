namespace WebApi.Core.Events
{
    public class StatusCodeChecked
    {
        public int ResourceId { get; }
        public StatusCodeChecked( int resourceId )
        {
            ResourceId = resourceId;
        }
    }
}
