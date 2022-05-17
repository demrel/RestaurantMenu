using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Application.Interfaces;
using RestaurantMenu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Infrastructure.Data
{
    public class AppDbContext : DbContext, IDBContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> PriceHistories { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }

        public async Task<int> SaveChangesAsync()
        {
          return await base.SaveChangesAsync();
        }
    }
}
