using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services
{
    public interface IProductsStockService
    {
        Task<IEnumerable<ProductStockDto>> GetAll();
        Task<ProductStockDto> GetProductById(int id);

        Task Create(ProductStockDto product);
        Task Update(ProductStockDto product);
        Task Delete(int id);
    }
}
