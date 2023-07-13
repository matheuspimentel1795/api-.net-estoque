using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface IProductsStockRepository
    {
        Task<IEnumerable<ProductsStock>> GetAll();
        Task<ProductsStock> GetProductById(int id);
        Task<ProductsStock> Create(ProductsStock product);
        Task<ProductsStock> Update(ProductsStock product);
        Task<ProductsStock> Delete(int id);
    }
}
