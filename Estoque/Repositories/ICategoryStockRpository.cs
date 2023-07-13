using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface ICategoryStockRepository
    {
        Task<IEnumerable<CategoryStock>> GetAll();
        Task<IEnumerable<CategoryStock>> GetCategoriesProducts();

        Task<CategoryStock> GetCategoryById(int id);
        Task<CategoryStock> Create(CategoryStock category);
        Task<CategoryStock> Update(CategoryStock category);
        Task<CategoryStock> Delete(int id);
    }
}
