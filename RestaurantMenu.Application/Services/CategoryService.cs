using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Application.Exceptions;
using RestaurantMenu.Application.Helpers;
using RestaurantMenu.Application.Interfaces;
using RestaurantMenu.Application.Models;
using RestaurantMenu.Domain.Entities;

namespace RestaurantMenu.Application.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IDBContext _context;
        private readonly IPathProvider _pathProvider;

        public CategoryService(IDBContext context, IPathProvider pathProvider)
        {
            _context = context;
            _pathProvider = pathProvider;
        }

        public void Add(CategoryDTO categoryDto,string base64Image)
        {
            bool categoryIsExist = _context.Categories.Any(c=>c.Name==categoryDto.Name);
            if (categoryIsExist) throw new DuplicateException("Category is Duplicated");


            if (!string.IsNullOrEmpty(base64Image))
                categoryDto.ImageUrl = AppImageFileHelper.AddImage(base64Image, _pathProvider.WWWrootPath);
            
            _context.Categories.Add(new Category(categoryDto.Name, categoryDto.Description, categoryDto.ImageUrl));
            _context.SaveChanges();
        }

        public async Task Update(CategoryDTO categoryDto,string base64Image)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c=>c.Id==categoryDto.Id);
            if (category==null) throw new NotFoundException("Category not Found when update");

            if (!string.IsNullOrEmpty(base64Image))
            {
                AppImageFileHelper.RemoveImage(category.ImageUrl, _pathProvider.WWWrootPath);
                categoryDto.ImageUrl = AppImageFileHelper.AddImage(base64Image, _pathProvider.WWWrootPath);
            }
            category.Update(categoryDto.Name, categoryDto.Description, categoryDto.ImageUrl);
            _context.SaveChanges();
        }

        public async Task Remove(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null) throw new NotFoundException("Category not Found when delete");

            if (!string.IsNullOrEmpty(category.ImageUrl))
                AppImageFileHelper.RemoveImage(category.ImageUrl, _pathProvider.WWWrootPath);
            
            _context.Categories.Remove(category);
            _context.SaveChanges();

        }

        public async Task<PaginationList<CategoryDTO>> GetAllByPagination(int pageNumber,int pageSize=20)
        {
            var listData= _context.Categories.Select(c => new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
            }).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return new PaginationList<CategoryDTO>(await listData.ToListAsync(),await listData.CountAsync(), pageNumber, pageSize);
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            return await _context.Categories.Select(c => new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
            }).ToListAsync();
            
        }

        public async Task<List<CategorySelectListDTO>> GetSelectList()
        {
            return await  _context.Categories.Select(c => new CategorySelectListDTO()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();
        }

        public async Task<CategoryDTO> GetById(int id)
        {
           return await  _context.Categories.Select(c => new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
            }).FirstOrDefaultAsync(c=>c.Id==id);  
        }


    }
}
