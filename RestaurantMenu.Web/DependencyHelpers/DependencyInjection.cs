using RestaurantMenu.Application.Interfaces;
using RestaurantMenu.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Web.DependencyHelpers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddSingleton<IPathProvider, PathProvider>();

            return services;
        }

        public static IServiceCollection AddCorsService(this IServiceCollection services, string corsName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsName,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:44487",
                                                         " https://192.168.31.227:44487")
                                                        .AllowAnyOrigin()
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod();
                                  });
            });

            return services;
        }
    }
}
