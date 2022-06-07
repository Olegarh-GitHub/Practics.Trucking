using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Practics.Trucking.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models;
using Practics.Trucking.Infrastructure.Repositories;

namespace Practics.Trucking.Configuration
{
    public static class EntityFrameworkConfiguration
    {
        public static void AddEntityFrameworkCoreORM(this IServiceCollection services, IConfiguration configuration)
        {
            string truckingConnection = configuration.GetConnectionString("Trucking");

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(truckingConnection), ServiceLifetime.Transient);

            services.AddTransient<IAsyncRepository<User>, EntityFrameworkAsyncRepository<User>>();
            services.AddTransient<IAsyncRepository<UserInfo>, EntityFrameworkAsyncRepository<UserInfo>>();
            services.AddTransient<IAsyncRepository<Order>, EntityFrameworkAsyncRepository<Order>>();
            services.AddTransient<IAsyncRepository<Product>, EntityFrameworkAsyncRepository<Product>>();
            services.AddTransient<IAsyncRepository<Specification>, EntityFrameworkAsyncRepository<Specification>>();
            services.AddTransient<IAsyncRepository<Producer>, EntityFrameworkAsyncRepository<Producer>>();
            services.AddTransient<IAsyncRepository<ProducerInfo>, EntityFrameworkAsyncRepository<ProducerInfo>>();
            services.AddTransient<IAsyncRepository<Session>, EntityFrameworkAsyncRepository<Session>>();
        }
    }
}
