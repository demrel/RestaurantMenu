using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Application.Helpers
{
    public class AppImageFileHelper
    {
        public static string AddImage(string base64Image, string path)
        {
            var indexofRemoving = base64Image.IndexOf(',') + 1;
            var imageBytes = Convert.FromBase64String(base64Image[indexofRemoving..]);
            var a=base64Image[indexofRemoving..];
            using Stream stream = new MemoryStream(imageBytes);

            if (!Directory.Exists(""))
                Directory.CreateDirectory(path);

            var fileExtension = GetFileExtension(base64Image);
            if (fileExtension == string.Empty) throw new Exception("");
            
            string fileName = Guid.NewGuid().ToString() + fileExtension;

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                stream.CopyTo(fileStream);
            }
            return  fileName;
        }

        public static void RemoveImage(string fileName,string rootPath)
        {
            var path=Path.Combine(rootPath, fileName);
            if (File.Exists(path))
                File.Delete(path);
        }

        private static string GetFileExtension(string base64String) =>
             base64String[0..5].ToUpper() switch
             {
                 "IVBOR" => ".png",
                 "/9J/4" => ".jpg",
                 _ => string.Empty,
             };

    }
}
