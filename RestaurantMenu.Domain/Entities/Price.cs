using RestaurantMenu.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Domain.Entities
{
    public class Price : BaseEntity
    {
        public decimal Value { get;private set; }
        public DateTimeOffset CreatedTime { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public Price()
        {

        }

        public Price(decimal value)
        {
            Guards.Guard.Defend(() => value<=0 , "Price value can not be negative or zero");
            Value = value;
            CreatedTime = DateTimeOffset.UtcNow;
        }


    }
}
