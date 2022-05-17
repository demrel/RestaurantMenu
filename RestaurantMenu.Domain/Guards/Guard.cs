using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Domain.Guards
{
    public static class Guard
    {
        public static void Defend(Func<bool> fromPredicate, string message)
        {
            if (fromPredicate())  throw new GuardException(message);
        }
    }
}
