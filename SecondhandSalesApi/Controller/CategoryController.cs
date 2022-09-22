using AutoMapper;
using Data.Model;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace SecondhandSalesApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<CategoryDto, Category>
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;


        public CategoryController(ICategoryService categoryService, IMapper mapper) : base(categoryService, mapper)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }
    }
}
