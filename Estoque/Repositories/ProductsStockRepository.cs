using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public class ProductsStockRepository : IProductsStockRepository
    {
        private readonly AppDbContext _context;
        public ProductsStockRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProductsStock> Create(ProductsStock product)
        {
            _context.ProductsStock.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ProductsStock> Delete(int id)
        {
            var product = await GetProductById(id);
            _context.ProductsStock.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<ProductsStock>> GetAll()
        {
            return await _context.ProductsStock.ToListAsync();
        }

        public async Task<ProductsStock> GetProductById(int id)
        {
            return await _context.ProductsStock.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProductsStock> Update(ProductsStock product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
