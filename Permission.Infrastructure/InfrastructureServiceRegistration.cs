using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Permissions.Core.Domain;
using Permissions.Core.Interfaces;
using Permissions.Core.Interfaces.Elasticsearch;
using Permissions.Infrastructure.Elasticsearch;
using Permissions.Infrastructure.Persistence;
using Permissions.Infrastructure.Repositories;
using Permissions.Infrastructure.utils;

namespace Permissions.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PermissionDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("ConnectionStrings")));

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryBase<>));
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IElasticsearchService<Permission>, ElasticsearchService>();
            return services;
        }
    }
}
