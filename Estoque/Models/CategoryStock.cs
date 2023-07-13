using System.ComponentModel.DataAnnotations;

namespace VShop.ProductApi.Models
{
    public class CategoryStock
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "O nome do categoria é obrigatorio")]
        public string? Name { get; set; }

        public ICollection<ProductsStock>? Products { get; set; }
    }
}
