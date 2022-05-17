using RestaurantMenu.Application.Models;


namespace RestaurantMenu.Application.Interfaces
{
    public interface IProductService
    {
        void Add(ProductDTO productDTO, string base64Image);
        Task Update(ProductDTO productDTO, string base64Image);
        Task Remove(int id);
        Task<PaginationList<ProductDTO>> GetAllByPagination(int pageNumber, int pageSize = 20);
        Task<ProductGetByIdDTO> GetById(int id);
        Task<PaginationList<ProductGroopByNameDTO>> GetGroupedByCategory(int pageNumber, int pageSize = 20, string nameFilter = "", string ingRidientFilter = "", string categoryNameFilter = "");
    }
}
