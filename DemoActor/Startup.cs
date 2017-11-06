// ***********************************************************************
// Solution         : VsTemplate
// Project          : NetCoreActor
// File             : Startup.cs
// Updated          : 2017-11-02 14:34
// ***********************************************************************
// <copyright>
//     Copyright © 2016 - 2017 Kolibre Credit Team. All rights reserved.
// </copyright>
// ***********************************************************************


using System.Diagnostics.CodeAnalysis;
using System.Fabric;
using KC.Foundation.Data;
using KC.Foundation.SF;
using KC.Foundation.SF.Logging;
using KC.Foundation.SF.Logging.AI;
using KC.Foundation.SF.Logging.Database;
using KC.Foundation.SF.Logging.Email;
using KC.Foundation.Utilities.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace DemoActor
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        public void Configure(IConfigurationBuilder builder, IHostingEnvironment env, StatefulServiceContext context, ActorTypeInformation actorType)
        {
            // IHostingEnvironment env, StatefulServiceContext context, ActorTypeInformation actorType 是已知参数
            // 在这个方法中主要是配置 IConfigurationBuilder
        }

        [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
        public void ConfigureServices(IServiceCollection services, IConfiguration config, IHostingEnvironment environment, StatefulServiceContext serviceContext, ActorTypeInformation actorType)
        {
            string clusterRootUri = string.Concat(serviceContext.ServiceName.Scheme, ":", serviceContext.ServiceName.Segments[0], serviceContext.ServiceName.Segments[1]);
            services.Configure<ServiceFabricOption>(options => options.ClusterRootUri = clusterRootUri);
            services.Configure<DataOptions>(config.GetSection("Data"));

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
        }

        public void ConfigureDevelopmentServices(IServiceCollection services, IConfiguration config, IHostingEnvironment environment, StatefulServiceContext serviceContext, ActorTypeInformation actorType)
        {
            // 这里的 config 已经是经过 Configure 方法配置后的 IConfiguration

            services.Configure<ApplicationInsightsLoggerOptions>(config.GetSection("Logging:ApplicationInsightsLogger"));
            services.Configure<TraceLoggerOptions>(config.GetSection("Logging:TraceLogger"));
            services.Configure<FileLoggerOptions>(config.GetSection("Logging:FileLogger"));
            services.Configure<DatabaseLoggerOptions>(config.GetSection("Logging:DatabaseLogger"));
            services.Configure<EmailLoggerOptions>(config.GetSection("Logging:EmailLogger"));
            services.AddApplicationInsightsLogger();
            services.AddTraceLogger();
            services.AddFileLogger();
            services.AddDatabaseLogger();
            services.AddEmailLogger();

            ConfigureServices(services, config, environment, serviceContext, actorType);
        }

        public void ConfigureTestServices(IServiceCollection services, IConfiguration config, IHostingEnvironment environment, StatefulServiceContext serviceContext, ActorTypeInformation actorType)
        {
            services.Configure<ApplicationInsightsLoggerOptions>(config.GetSection("Logging:ApplicationInsightsLogger"));
            services.Configure<FileLoggerOptions>(config.GetSection("Logging:FileLogger"));
            services.Configure<DatabaseLoggerOptions>(config.GetSection("Logging:DatabaseLogger"));
            services.Configure<EmailLoggerOptions>(config.GetSection("Logging:EmailLogger"));
            services.AddApplicationInsightsLogger();
            services.AddFileLogger();
            services.AddDatabaseLogger();
            services.AddEmailLogger();

            ConfigureServices(services, config, environment, serviceContext, actorType);
        }

        public void ConfigureProductionServices(IServiceCollection services, IConfiguration config, IHostingEnvironment environment, StatefulServiceContext serviceContext, ActorTypeInformation actorType)
        {
            services.Configure<ApplicationInsightsLoggerOptions>(config.GetSection("Logging:ApplicationInsightsLogger"));
            services.Configure<FileLoggerOptions>(config.GetSection("Logging:FileLogger"));
            services.Configure<DatabaseLoggerOptions>(config.GetSection("Logging:DatabaseLogger"));
            services.Configure<EmailLoggerOptions>(config.GetSection("Logging:EmailLogger"));
            services.AddApplicationInsightsLogger();
            services.AddFileLogger();
            services.AddDatabaseLogger();
            services.AddEmailLogger();

            ConfigureServices(services, config, environment, serviceContext, actorType);
        }
    }
}