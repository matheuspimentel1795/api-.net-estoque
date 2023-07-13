namespace VShop.ProductApi.Models
{
    public class ProductsStock
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public CategoryStock? Category { get; set; } // relacionarmento com categoriaStock
        public int CategoryId { get; set; }
    }
}
