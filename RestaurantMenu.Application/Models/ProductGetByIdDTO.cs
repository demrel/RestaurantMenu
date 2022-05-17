using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Application.Models
{
    public class ProductGetByIdDTO
    {
        public int Id { get; set; } 
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string ImageUrl { get;  set; }
        public List<PriceDTO> Price { get; set; } 
        public List<string> Ingridients { get; set; }=new ();
    }
}
