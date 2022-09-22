using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dto
{
    public class OfferDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add your user id,It is required field")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please add the product ıd of the product you want to buy,It is required field")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the price you offer,It is required field")]
        public decimal Price { get; set; }
        [JsonIgnore]
        public bool IsApproved { get; set; }
    }
}
