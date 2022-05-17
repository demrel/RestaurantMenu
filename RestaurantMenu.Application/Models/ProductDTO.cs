using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Application.Models
{
    public class ProductDTO
    {
        public int Id { get; set; } 
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string ImageUrl { get;  set; }
        public decimal Price { get; set; } 
        public int CategoryId { get; set; }
        public List<string> Ingridients { get; set; }=new ();
    }
}
