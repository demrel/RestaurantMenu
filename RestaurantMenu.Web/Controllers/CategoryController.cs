using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenu.Application.Interfaces;
using RestaurantMenu.Application.Models;
using RestaurantMenu.Web.Models;
using RestaurantMenu.Web.ViewModels;

namespace RestaurantMenu.Web.Controllers
{

    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
            return await _categoryService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> Get([FromQuery] int id)
        {
            var category= await _categoryService.GetById(id);
            if (category == null) return NotFound();
            return category;
        }

        [HttpPost]
        public  OkResult Create([FromBody] CreateCategoryModel model)
        {
            _categoryService.Add(new CategoryDTO() { Name=model.postValue.Name,Description=model.postValue.Description},model.postValue.ImageBase64);
            return Ok();
        }


        [HttpPut]
        public OkResult Update([FromBody] CreateUpdateVM<CategoryDTO> model)
        {
            _categoryService.Update(model.UpdateModelDTO, model.ImageBase64);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await  _categoryService.Remove(id);
            return Ok();
        }

    }
}
