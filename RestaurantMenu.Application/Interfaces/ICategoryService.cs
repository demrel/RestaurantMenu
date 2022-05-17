using RestaurantMenu.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Application.Interfaces
{
    public interface ICategoryService
    {
        void Add(CategoryDTO categoryDto,string base64Image);
        Task Update(CategoryDTO categoryDto,string base64Image);
        Task Remove(int id);
        Task<PaginationList<CategoryDTO>> GetAllByPagination(int pageNumber, int pageSize = 20);
        Task<CategoryDTO> GetById(int id);
        Task<List<CategorySelectListDTO>> GetSelectList();
        Task<List<CategoryDTO>> GetAll();
    }
}
