using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services
{
    public interface ICategoryStockService
    {
        Task<IEnumerable<CategoryStockDto>> GetCategories();
        Task<IEnumerable<CategoryStockDto>> GetCategoriesProducts();
        Task<CategoryStockDto> GetCategoryById(int id);

        Task AddCategory(CategoryStockPayloadDto categoryDto);
        Task UpdateCategory(CategoryStockDto categoryDto);
        Task RemoveCategory(int id);
    }
}
