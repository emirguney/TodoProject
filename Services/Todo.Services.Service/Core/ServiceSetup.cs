using DBHelper.BaseDto;
using DBHelper.Connection;
using DBHelper.Connection.Mongo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Services.Data.Implementation;
using Todo.Services.Data.Interface;
using Todo.Services.Data.Settings;
using Todo.Services.Service.Implementation;
using Todo.Services.Service.Interface;

namespace Todo.Services.Service.Core
{
    public static class ServiceSetup
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddServicesForRepository(services);
            AddServicesForServices(services);
            AddServicesForLangServices(services);
        }

        public static void AddServicesForRepository(this IServiceCollection services)
        {
            services.AddTransient<IDbConfiguration, TodoDbSetting>();
            services.AddTransient<IConnectionFactory, MongoConnectionFactory>();
            services.AddTransient<IBaseDatabaseSettings, MongoDatabaseSettings>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITodoRepository, TodoRepository>();
        }
        public static void AddServicesForServices(this IServiceCollection services)
        {
            services.AddTransient<ITodoService, TodoService>();
        }

        public static void AddServicesForLangServices(this IServiceCollection services)
        {

        }
    }
    }
