using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dto
{
    public class CategoryDto
    {

        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add Category name,It is required field")]
        public string CategoryName { get; set; }

    }
}
