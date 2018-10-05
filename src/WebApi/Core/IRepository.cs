namespace WebApi.Core
{
    public interface IRepository
    {
        int CreatePageSource(int resourceId, string html);

        void Commit();
        void Rollback();
    }
}
