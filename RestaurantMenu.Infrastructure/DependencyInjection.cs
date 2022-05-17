using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantMenu.Application.Interfaces;
using RestaurantMenu.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
              options.UseNpgsql(
                  configuration.GetConnectionString("DefaultConnection"),
                  b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));


            services.AddScoped<IDBContext>(provider => provider.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}
