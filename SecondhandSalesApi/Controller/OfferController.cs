using AutoMapper;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace SecondhandSalesApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService OfferService;
        private readonly IProductService productService;
        private readonly IMapper mapper;


        public OfferController(IOfferService OfferService, IMapper mapper, IProductService productService)
        {
            this.mapper = mapper;
            this.OfferService = OfferService;
            this.productService = productService;
        }

        [HttpPost("Give Offer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult GiveOffer([FromBody] OfferDto dto)
        {
            if (ModelState.IsValid)
            {
                var resultProduct = productService.GetById(dto.ProductId);
                if (resultProduct != null)
                {
                    if (resultProduct.Response.IsOfferable == true)
                    {
                        OfferService.Insert(dto);
                        return StatusCode(201, dto);
                    }
                    else
                    {
                        return BadRequest("This product cannot be bid.");
                    }


                }
                else
                {
                    return BadRequest("Product not found");

                }
            }


            return BadRequest();


        }

    }
}
