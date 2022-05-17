using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Application.Models
{
    public class PriceDTO
    {
        public decimal Value { get;  set; }
        public DateTimeOffset CreatedTime { get;  set; }

    }
}
