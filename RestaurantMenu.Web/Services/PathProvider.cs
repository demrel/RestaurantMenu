using RestaurantMenu.Application.Interfaces;

namespace RestaurantMenu.Web.Services
{
    public class PathProvider : IPathProvider
    {
        private IWebHostEnvironment _env;

        public PathProvider(IWebHostEnvironment env)
        {
            _env = env;
        }


         //IWebHostEnvironment WebRootPath return null because 
         //   in evrimoment dosnt exsist any folder with name wwwroot
        public string WWWrootPath => _env.WebRootPath;
    }
}
