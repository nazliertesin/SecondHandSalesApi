using System.ComponentModel.DataAnnotations;

namespace Base
{
    public class TokenRequest
    {

        [UserNameAttribute]
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "UserName is required field")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required field")]
        public string Password { get; set; }


    }
}
