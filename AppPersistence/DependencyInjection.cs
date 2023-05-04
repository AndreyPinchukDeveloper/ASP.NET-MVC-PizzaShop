using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopApplication.Interfaces;

namespace AppPersistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<OrderDbContext>(options =>
            { 
                options.UseSqlite(connectionString); 
            });
            services.AddScoped<IOrderDbContext>(provider =>
                provider.GetService<OrderDbContext>());

            return services;
        }
    }
}
