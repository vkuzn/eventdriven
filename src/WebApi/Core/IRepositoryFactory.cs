using System;

namespace WebApi.Core
{
    public interface IRepositoryFactory
    {
        void Execute( Action<IRepository> action );
    }
}
