using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApi.Core;
using WebApi.Core.Events;
using WebApi.Infrastructure;

namespace WebApi
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        private MessageBus CreateMessageBus( IServiceProvider serviceProvider )
        {
            // Создаём и настраиваем шину сообщений

            var messageBus = new MessageBus();
            messageBus.Subscribe<StatusCodeChecked>( serviceProvider.GetService<SeleniumService>() );
            messageBus.Subscribe<ResourceCreated>( serviceProvider.GetService<StatusCodeChecker>() );
            messageBus.Subscribe<StatusCodeChecked>( serviceProvider.GetService<PagespeedChecker>() );
            messageBus.Subscribe<ResourceCreated>( serviceProvider.GetService<PagespeedChecker>() );

            return messageBus;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_1 );

            // Настраиваем экземпляры служб
            services
                .AddScoped<IRepositoryFactory, RepositoryFactory>()
                .AddScoped<SeleniumService>()
                .AddScoped<PagespeedChecker>()
                .AddScoped<StatusCodeChecker>()
                .AddScoped<IEventsDispatcher>( CreateMessageBus );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
