namespace RestaurantMenu.Application.Interfaces;

public interface IPathProvider
{
    string WWWrootPath { get; }
    string ImagePath => "/images/" + WWWrootPath;
}
