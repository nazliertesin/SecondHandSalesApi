using AutoMapper;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace SecondhandSalesApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldController : ControllerBase
    {
        private readonly ISoldService soldService;
        private readonly IUserService userService;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public SoldController(ISoldService soldService, IMapper mapper, IUserService userService, IProductService productService)
        {
            this.mapper = mapper;
            this.soldService = soldService;
            this.userService = userService;
            this.productService = productService;
        }


        [HttpPost("Buy the product")]
        public IActionResult BuyTheProduct([FromBody] SoldDto sold)
        {
            var user = userService.GetById(sold.CustomerId).Response;
            var product = productService.GetById(sold.ProductId).Response;
            if (user != null && product != null && product.IsSold == false)
            {
                sold.DateofPurchase = System.DateTime.Now;
                soldService.Insert(sold);
                ProductDto productDto = new ProductDto();
                productDto.IsOfferable = false;
                productDto.IsSold = true;
                productService.Update(product.Id, productDto);
                return Ok(sold);
            }

            return BadRequest();
        }
    }
}
