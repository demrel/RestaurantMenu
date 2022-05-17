using RestaurantMenu.Application.Models;

namespace RestaurantMenu.Web.ViewModels;

public class CreateCategoryModel
{
   public PostValue postValue { get; set; }
}

public class PostValue
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageBase64 { get; set; }
}
