using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Application.Models
{
    public class ProductGroopByNameDTO
    {
       public CategoryDTO Category { get; set; }
       public List<ProductDTO> Products { get; set; }
    }
}
