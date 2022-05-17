using RestaurantMenu.Domain.Entities.Base;


namespace RestaurantMenu.Domain.Entities
{
    public class Ingridient : BaseEntity
    {
        public string Name { get; private set; }
        public IList<Product> Products { get; set; }

        public Ingridient()
        {

        }

        public Ingridient(string name)
        {
            Guards.Guard.Defend(() => string.IsNullOrEmpty(name), "Ingridient name can not be null");
            Name = name.ToLower();
        }

    }
}
