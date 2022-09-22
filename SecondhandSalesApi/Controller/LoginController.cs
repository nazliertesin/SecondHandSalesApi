using Base;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace SecondhandSalesApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    //In this controller, the user gets tokens with her username and password and authenticates to the system here.
    public class LoginController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public LoginController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        //This method create token if model is valid
        [HttpPost("Login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = tokenService.GenerateToken(request);

            return response;
        }





    }
}
