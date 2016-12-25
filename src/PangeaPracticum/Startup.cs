using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PangeaPracticum.lib.Messaging;
using PangeaPracticum.lib.Messaging.Messages;
using PangeaPracticum.lib.Messaging.Processors;
using PangeaPracticum.lib;
using RawRabbit;
using RawRabbit.vNext;

namespace PangeaPracticum
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<RepositoryContext>();

            services.AddSingleton<IBusClient>(BusClientFactory.CreateDefault());
            services.AddTransient<IRepositoryService, RepositoryService>();
            services.AddTransient<IRepoLoader, GitHubHttpClient>();
            services.AddTransient<IBusMessageProcessor<LoadDataRequest>, LoadDataProcessor>();
            services.AddTransient<IBusPublisher, BusPublisherService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            var processor = app.ApplicationServices.GetService<IBusMessageProcessor<LoadDataRequest>>();
            var bus = app.ApplicationServices.GetService<IBusClient>();
            bus.SubscribeAsync<LoadDataRequest>(async (msg, context) => { processor.Process(msg); });
        }

        
    }
}
