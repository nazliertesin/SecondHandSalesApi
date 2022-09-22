using AutoMapper;
using Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Linq;

namespace SecondhandSalesApi.Controller
{
    [ApiController]
    [Authorize]
    //User operations are done in this controller. Here, there are user adding, viewing offers, confirming and rejecting offers.
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;
        private readonly IOfferService offerService;
        private readonly IProductService productService;
        private readonly IMapper mapper;


        public UserController(IUserService userService, IProductService productService, IOfferService offerService, IMapper mapper)
        {
            this.userService = userService;
            this.offerService = offerService;
            this.productService = productService;
            this.mapper = mapper;
        }
        //This method converts the imported user password to a salted hash password and records the user.
        [AllowAnonymous]
        [HttpPost("Sign up")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Signup([FromBody] UserDto dto)
        {

            if (ModelState.IsValid)
            {
                dto.Password = ConvertPasswordToHash(dto.Password);
                var response = userService.Insert(dto);

                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("Confirm the Offer")]
        public IActionResult ConfirmTheOffer(int offerId)
        {
            var offer = offerService.GetById(offerId).Response;
            if (offer != null)
            {
                offer.IsApproved = true;
                offerService.Update(offerId, offer);
                return Ok(offer);
            }

            return BadRequest();
        }

        [HttpPut("Reject The Offer")]
        public IActionResult rejectTheOffer(int offerId)
        {
            var offer = offerService.GetById(offerId).Response;
            if (offer != null)
            {
                offer.IsApproved = false;
                offerService.Update(offerId, offer);
                return Ok(offer);
            }

            return BadRequest();
        }

        [HttpGet("Get My Offer")]
        public IActionResult GetMyOffers(int Userid)
        {
            var user = userService.GetById(Userid).Response;

            if (user != null)
            {
                var response = offerService.GetAll().Response.Where(x => x.UserId == Userid && x.IsApproved == false);
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }


        }

        //Convert user password to salted hash code

        [NonAction]
        public string ConvertPasswordToHash(string password)
        {
            string salt = CreateSalt(3);
            string hashedPassword = GenerateSHA256Hash(password, salt);
            return hashedPassword;
        }
        //
        [NonAction]

        //Create  salt for user password
        public string CreateSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        [NonAction]
        //Create hash code for user password
        public string GenerateSHA256Hash(string input, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            System.Security.Cryptography.SHA256Managed sHA256Managed = new
                System.Security.Cryptography.SHA256Managed();

            byte[] hash = sHA256Managed.ComputeHash(bytes);
            string result = Convert.ToHexString(hash);
            return result;
        }






    }
}
