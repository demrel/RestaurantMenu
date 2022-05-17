using RestaurantMenu.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }

        public Category() { }


        public Category(string name,string description,string imageUrl)
        {
            Guards.Guard.Defend(() => string.IsNullOrWhiteSpace(name), "Category Name can not be Empty");
            Name= name;
            Description= description;
            ImageUrl = imageUrl;
           
        }

   

        public void Update(string name, string description, string imageUrl)
        {
            Guards.Guard.Defend(() => string.IsNullOrWhiteSpace(name), "Category Name can not be Empty");
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }


    }
}
