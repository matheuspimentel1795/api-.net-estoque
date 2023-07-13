using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs
{
    public class CategoryStockPayloadDto
    {
        [JsonIgnore]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public ICollection<ProductsStock>? Products { get; set; }
    }
}
