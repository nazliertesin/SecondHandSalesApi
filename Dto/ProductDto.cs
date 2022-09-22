
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dto
{
    public class ProductDto
    {
        [JsonIgnore]
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Supplier Id is required field")]
        public virtual int SupplierId { get; set; }


        [Required(ErrorMessage = "CategoryId is required field")]
        public virtual int CategoryId { get; set; }


        [Required(ErrorMessage = "Product Name is required field")]
        [MaxLength(100, ErrorMessage = "Password length must be a maximum of 100 characters")]
        public virtual string ProductName { get; set; }


        [Required(ErrorMessage = "Description is required field")]
        [MaxLength(500, ErrorMessage = "Password length must be a maximum of 100 characters")]
        public virtual string Description { get; set; }


        [Required(ErrorMessage = "Brand is required field")]
        public virtual string Brand { get; set; }


        [Required(ErrorMessage = "Color is required field")]
        public virtual string Color { get; set; }


        [Required(ErrorMessage = "Price is required field")]
        public virtual decimal Price { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "IsSold is required field")]
        public virtual bool IsSold { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "IsOfferable is required field")]
        public virtual bool IsOfferable { get; set; }



    }
}
