using System.Diagnostics;
using WebApi.Core.Events;

namespace WebApi.Core
{
    public class PagespeedChecker : IEventListener<StatusCodeChecked>, IEventListener<ResourceCreated>
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public PagespeedChecker( IRepositoryFactory repositoryFactory )
        {
            Debug.WriteLine( $"constuctor: {this.GetType().FullName}" );
            _repositoryFactory = repositoryFactory;
        }

        public void Handle( StatusCodeChecked msg, IEventsDispatcher eventsDispatcher )
        {
            Debug.WriteLine( $"PagespeedChecker: handling StatusCodeChecked({msg.ResourceId})" );

            _repositoryFactory.Execute( repository =>
             {
                 repository.Commit();
             } );
        }

        public void Handle( ResourceCreated msg, IEventsDispatcher eventsDispatcher )
        {
            Debug.WriteLine( $"PagespeedChecker: handling ResourceCreated({msg.ResourceId})" );

            _repositoryFactory.Execute( repository =>
            {
                repository.Commit();
            } );
        }
    }
}
