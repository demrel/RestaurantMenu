using Microsoft.Extensions.DependencyInjection;
using RestaurantMenu.Application.Interfaces;
using RestaurantMenu.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IIngridientService, IngridientService>();
            return services;
        }
    }
}
