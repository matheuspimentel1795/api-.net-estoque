using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class ProductStockService : IProductsStockService
    {
        private readonly IProductsStockRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductStockService(IProductsStockRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Create(ProductStockDto product)
        {
            var productEntity = _mapper.Map<ProductsStock>(product);
            await _productRepository.Create(productEntity);
        }

        public async Task Delete(int id)
        {
            var productEntity = _productRepository.GetProductById(id).Result;
            await _productRepository.Delete(productEntity.CategoryId);
        }

        public async Task<IEnumerable<ProductStockDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductStockDto>>(products);
        }

        public async Task<ProductStockDto> GetProductById(int id)
        {
            var productEntity = await _productRepository.GetProductById(id);
            return _mapper.Map<ProductStockDto>(productEntity);
        }

        public async Task Update(ProductStockDto product)
        {
            var productEntity = _mapper.Map<ProductsStock>(product);
            await _productRepository.Update(productEntity);
        }
    }
}
