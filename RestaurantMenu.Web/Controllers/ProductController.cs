using Microsoft.AspNetCore.Mvc;
using RestaurantMenu.Application.Interfaces;
using RestaurantMenu.Application.Models;
using RestaurantMenu.Web.Models;
using RestaurantMenu.Web.ViewModels;

namespace RestaurantMenu.Web.Controllers
{
  
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationList<ProductDTO>>> Get([FromQuery] PaginationModel pagination)
        {
           return await _productService.GetAllByPagination(pagination.PageNumber);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetByIdDTO>> Get([FromQuery] int id)
        {
            var product= await _productService.GetById(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpGet("[action]/GetGroupBy")]
        public async Task<ActionResult<PaginationList<ProductGroopByNameDTO>>> Get([FromQuery] FilterModel filter)
        {
            return  await _productService.GetGroupedByCategory(filter.paginationModel.PageNumber
                                                              ,filter.paginationModel.PageSize
                                                              ,filter.NameFilter,filter.IngRidientFilter
                                                              ,filter.CategoryNameFilter);
        }

        [HttpPost]
        public  OkResult Create([FromBody] CreateUpdateVM<ProductDTO> model)
        {
            _productService.Add(model.UpdateModelDTO,model.ImageBase64);
            return Ok();
        }


        [HttpPut]
        public OkResult Update([FromBody] CreateUpdateVM<ProductDTO> model)
        {
            _productService.Update(model.UpdateModelDTO, model.ImageBase64);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await  _productService.Remove(id);
            return Ok();
        }

    }
}
