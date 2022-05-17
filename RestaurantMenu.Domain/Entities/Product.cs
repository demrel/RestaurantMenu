using RestaurantMenu.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IList<Price> PriceHistories { get; private set; }
        public List<Ingridient> Ingridients { get;  set; }
        public string ImageUrl { get; private set; }
        public int CategoryId { get;private set; }
        public Category Category { get; private set; }


        public Product() { }

        public Product(string name, string description, string imageUrl,int categoryId)
        {
            Guards.Guard.Defend(() => string.IsNullOrWhiteSpace(name), "Product Name can not be Empty");
            Guards.Guard.Defend(() => categoryId<=0, "Product CategoryId can not be zero or negative");
            Name = name;
            ImageUrl = imageUrl;
            CategoryId = categoryId;    
            Description = description;
        }

        public void Update(string name, string description, string imageUrl,int categoryId)
        {
            Guards.Guard.Defend(() => string.IsNullOrWhiteSpace(name), "Product Name can not be Empty");
            Guards.Guard.Defend(() => categoryId <= 0, "Product CategoryId can not be zero or negative");
            Name = name;
            Description = description;
            CategoryId = categoryId;
            ImageUrl = imageUrl;
        }

        public void AddPrice(decimal value)
        {
            var lastPrice = PriceHistories.OrderByDescending(c => c.CreatedTime).Select(c=>c.Value).FirstOrDefault();

            if (lastPrice != value)
                PriceHistories.Add(new Price(value));
        }

        public void AddIngridients(List<Ingridient> ingridients)
        {
            Ingridients.AddRange(ingridients);
        }


        public void UpdateIngridients(List<Ingridient> ingridients)
        {
            Ingridients.RemoveAll(ing => !ingridients.Contains(ing));
            Ingridients.AddRange(ingridients);
        }
       

    }
}
