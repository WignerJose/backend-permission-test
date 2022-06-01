using Permissions.Infrastructure.utils;
using System.Reflection;

namespace Permissions.Api
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.Configure<DataBaseConfig>(configuration.GetSection("ConnectionStrings"));
            services.Configure<ElasticsearchConfig>(configuration.GetSection("ElasticsearchSettings"));
            return services;
        }
    }
}
