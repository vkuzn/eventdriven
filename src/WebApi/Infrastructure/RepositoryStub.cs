using System.Diagnostics;
using WebApi.Core;

namespace WebApi.Infrastructure
{
    public class RepositoryStub : IRepository
    {
        public RepositoryStub(  )
        {
            Debug.WriteLine( "new RepositoryStub()" );
        }

        public void Commit()
        {
            Debug.WriteLine( "RepositoryStub.Commit()" );
        }

        public void Rollback()
        {
            Debug.WriteLine( "RepositoryStub.Rollback()" );
        }

        public int CreatePageSource( int resourceId, string html )
        {
            return 5;
        }
    }
}
