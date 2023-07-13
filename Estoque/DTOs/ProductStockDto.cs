using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs
{
    public class ProductStockDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public CategoryStock? Category { get; set; } 
        public int CategoryId { get; set; }
    }
}
