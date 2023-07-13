using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs
{
    public class CategoryStockDto
    {
       
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "O nome do categoria é obrigatorio")]
        public string? Name { get; set; }
      
        public ICollection<ProductsStock>? Products { get; set; }
    }
}
