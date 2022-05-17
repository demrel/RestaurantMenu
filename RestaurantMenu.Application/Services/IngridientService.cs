using RestaurantMenu.Application.Interfaces;
using RestaurantMenu.Domain.Entities;

namespace RestaurantMenu.Application.Services
{
    public class IngridientService : IIngridientService
    {
        private readonly IDBContext _context;

        public IngridientService(IDBContext context)
        {
            _context = context;
        }

        public List<Ingridient> AddIngiridents(List<string> names)
        {
            var existedIngridients = GetExistedIngridientsFromList(names);

            var newGeneratedIngridients = GenerateUnExistedIngridientsFromList(names, existedIngridients);
            _context.Ingridients.AddRange(newGeneratedIngridients);
            return existedIngridients.Concat(newGeneratedIngridients).ToList();

        }

        private IEnumerable<Ingridient> GetExistedIngridientsFromList(List<string> name) =>
            _context.Ingridients.Where(c => name.Contains(c.Name)).AsEnumerable();

        private static IEnumerable<Ingridient> GenerateUnExistedIngridientsFromList(List<string> names, IEnumerable<Ingridient> existedIngridients) =>
                names.Except(existedIngridients.Select(c => c.Name)).Select(c => new Ingridient(c));





    }
}
