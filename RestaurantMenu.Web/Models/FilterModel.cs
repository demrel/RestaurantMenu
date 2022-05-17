namespace RestaurantMenu.Web.Models
{
    public class FilterModel
    {
       public  string NameFilter { get; set; } = "";
       public  string IngRidientFilter { get; set; } = "";
       public  string CategoryNameFilter { get; set; } = "";
       public  PaginationModel paginationModel { get; set; }
    }
}
