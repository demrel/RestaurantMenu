using RestaurantMenu.Application.Models;

namespace RestaurantMenu.Web.ViewModels;

public class CreateUpdateVM<T>
{
    public T UpdateModelDTO { get; set; }
    public string ImageBase64 { get; set; }
}
