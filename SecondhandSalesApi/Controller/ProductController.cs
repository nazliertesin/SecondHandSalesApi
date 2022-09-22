using AutoMapper;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace SecondhandSalesApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService ProductService;
        private readonly IMapper mapper;


        public ProductController(IProductService ProductService, IMapper mapper)
        {
            this.mapper = mapper;
            this.ProductService = ProductService;
        }

        [HttpPost("Add Product")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult AddProduct([FromBody] ProductDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = ProductService.Insert(dto);
                return StatusCode(201, result);
            }
            return BadRequest();
        }
    }
}