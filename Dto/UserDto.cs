using System.ComponentModel.DataAnnotations;

namespace Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName is required field")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required field")]
        [MinLength(8, ErrorMessage = "Password length must be at least 8 characters.")]
        [MaxLength(20, ErrorMessage = "Password length must be a maximum of 20 characters")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Email is required field")]
        [EmailAddress(ErrorMessage = "Email is not in correct format")]
        public string Email { get; set; }

    }
}
