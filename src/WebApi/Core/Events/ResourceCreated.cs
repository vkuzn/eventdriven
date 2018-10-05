namespace WebApi.Core.Events
{
    public class ResourceCreated
    {
        public int ResourceId { get; }

        public ResourceCreated( int resourceId )
        {
            ResourceId = resourceId;
        }
    }
}
