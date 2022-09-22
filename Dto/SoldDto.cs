using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dto
{
    public class SoldDto
    {
        [Required]
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please add your customer id,It is required field")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please add your product id,It is required field")]
        public int ProductId { get; set; }
        [Required]
        [JsonIgnore]
        public DateTime DateofPurchase { get; set; }


    }
}
