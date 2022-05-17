using RestaurantMenu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Application.Interfaces
{
    public interface IIngridientService
    {
        List<Ingridient> AddIngiridents(List<string> names);
    }
}
