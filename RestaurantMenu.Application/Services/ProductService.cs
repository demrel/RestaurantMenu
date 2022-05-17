using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Application.Exceptions;
using RestaurantMenu.Application.Helpers;
using RestaurantMenu.Application.Interfaces;
using RestaurantMenu.Application.Models;
using RestaurantMenu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IDBContext _context;
        private readonly IIngridientService _ingridientService;
        private readonly IPathProvider _pathProvider;

        public ProductService(IDBContext context, IIngridientService ingridientService, IPathProvider pathProvider)
        {
            _context = context;
            _ingridientService = ingridientService;
            _pathProvider = pathProvider;
        }

        public void Add(ProductDTO productDTO, string base64Image)
        {
            if (!string.IsNullOrEmpty(base64Image))
                productDTO.ImageUrl = AppImageFileHelper.AddImage(base64Image, _pathProvider.WWWrootPath);

            var newProduct = new Product(productDTO.Name, productDTO.Description, productDTO.ImageUrl, productDTO.CategoryId);
            newProduct.AddPrice(productDTO.Price);



            var ingridients = _ingridientService.AddIngiridents(productDTO.Ingridients);
            newProduct.AddIngridients(ingridients);

            _context.Products.Add(newProduct);
            _context.SaveChanges();

        }

        public async Task Update(ProductDTO productDTO, string base64Image)
        {
            var oldProduct = await _context.Products.FirstOrDefaultAsync(prod => prod.Id == productDTO.Id);
            if (oldProduct != null) return;

            if (!string.IsNullOrEmpty(base64Image))
            {
                AppImageFileHelper.RemoveImage(oldProduct.ImageUrl, _pathProvider.WWWrootPath);
                productDTO.ImageUrl = AppImageFileHelper.AddImage(base64Image, _pathProvider.WWWrootPath);
            }

            oldProduct.Update(productDTO.Name, productDTO.Description, productDTO.ImageUrl, productDTO.CategoryId);
            oldProduct.AddPrice(productDTO.Price);

            var ingridients = _ingridientService.AddIngiridents(productDTO.Ingridients);
            oldProduct.UpdateIngridients(ingridients);
            _context.SaveChanges();
        }

        public async Task Remove(int id)
        {
            var deleteProduct = await _context.Products.FirstOrDefaultAsync(prod => prod.Id == id);
            if (deleteProduct != null) throw new NotFoundException("Category not Found when delete");

            if (!string.IsNullOrEmpty(deleteProduct.ImageUrl))
                AppImageFileHelper.RemoveImage(deleteProduct.ImageUrl, _pathProvider.WWWrootPath);

            _context.Products.Remove(deleteProduct);
            _context.SaveChanges();

        }

        public async Task<PaginationList<ProductDTO>> GetAllByPagination(int pageNumber, int pageSize = 20)
        {
            var listData = _context.Products.Select(c => new ProductDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
            }).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return new PaginationList<ProductDTO>(await listData.ToListAsync(), await listData.CountAsync(), pageNumber, pageSize);
        }
        public async Task<PaginationList<ProductGroopByNameDTO>> GetGroupedByCategory(int pageNumber, int pageSize = 20, string nameFilter = "", string ingRidientFilter = "", string categoryNameFilter = "")
        {
            IQueryable<Product> query = _context.Products;


            if (!string.IsNullOrEmpty(nameFilter)) query = query.Where(c => c.Name == nameFilter);
            if (!string.IsNullOrEmpty(ingRidientFilter)) query = query.Where(c => c.Ingridients.Select(ing => ing.Name).Contains(ingRidientFilter));
            if (!string.IsNullOrEmpty(categoryNameFilter)) query = query.Where(c => c.Category.Name == categoryNameFilter);

            var listData = aplyFiltersAndReturnProductQuery(nameFilter, ingRidientFilter, categoryNameFilter).GroupBy(grp => new { grp.Category.Name, grp.Category.Description, grp.Category.ImageUrl }).Select((g) => new ProductGroopByNameDTO()
            {
                Category = new CategoryDTO() { Name = g.Key.Name, Description = g.Key.Description, ImageUrl = g.Key.ImageUrl },
                Products = g.Select(prod => new ProductDTO()
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Description = prod.Description,
                    ImageUrl = prod.ImageUrl,
                    Ingridients = prod.Ingridients.Select(ing => ing.Name).ToList(),
                    Price = prod.PriceHistories.OrderByDescending(pr => pr.CreatedTime).Select(pr => pr.Value).FirstOrDefault()
                }).ToList(),


            }).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return new PaginationList<ProductGroopByNameDTO>(await listData.ToListAsync(), await listData.CountAsync(), pageNumber, pageSize);
        }

        private  IQueryable<Product> aplyFiltersAndReturnProductQuery(string nameFilter = "", string ingRidientFilter = "", string categoryNameFilter = "")
        {
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrEmpty(nameFilter)) query = query.Where(c => c.Name == nameFilter);
            if (!string.IsNullOrEmpty(ingRidientFilter)) query = query.Where(c => c.Ingridients.Select(ing => ing.Name).Contains(ingRidientFilter));
            if (!string.IsNullOrEmpty(categoryNameFilter)) query = query.Where(c => c.Category.Name == categoryNameFilter);
            return query;
        }


        public async Task<ProductGetByIdDTO> GetById(int id)
        {
            return await _context.Categories.Select(c => new ProductGetByIdDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
            }).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
