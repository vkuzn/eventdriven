using System;
using WebApi.Core;

namespace WebApi.Infrastructure
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public void Execute( Action<IRepository> action )
        {
            //using(var db = new DbContext())
            {
                IRepository repository = new RepositoryStub(/* db */);
                action?.Invoke( repository );
            }
        }
    }
}
