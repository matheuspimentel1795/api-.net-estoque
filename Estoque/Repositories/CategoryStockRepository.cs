using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public class CategoryStockRepository : ICategoryStockRepository
    {
        private readonly AppDbContext _context;

        public CategoryStockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryStock> Create(CategoryStock category)
        {
            _context.CategoriesStock.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<CategoryStock> Delete(int id)
        {
            var category = await GetCategoryById(id);
            _context.CategoriesStock.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<CategoryStock>> GetAll()
        {
            return await _context.CategoriesStock.Include(c => c.Products).ToListAsync();
        }

        public async Task<IEnumerable<CategoryStock>> GetCategoriesProducts()
        {
            return await _context.CategoriesStock.Include(c => c.Products).ToListAsync();
        }

        public async Task<CategoryStock> GetCategoryById(int id)
        {
            return await _context.CategoriesStock.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<CategoryStock> Update(CategoryStock category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
