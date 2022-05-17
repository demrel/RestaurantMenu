using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Domain.Entities;

namespace RestaurantMenu.Application.Interfaces
{
    public interface IDBContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> PriceHistories { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }

        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}
