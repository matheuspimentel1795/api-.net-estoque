using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class CategoryStockService : ICategoryStockService
    {
        private readonly ICategoryStockRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryStockService(ICategoryStockRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task AddCategory(CategoryStockPayloadDto categoryDto)
        {
            var categoryEntity = _mapper.Map<CategoryStock>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
            categoryDto.CategoryId = categoryEntity.CategoryId;
        }

        public async Task<IEnumerable<CategoryStockDto>> GetCategories()
        {

            var categoriesEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryStockDto>>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryStockDto>> GetCategoriesProducts()
        {

            var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryStockDto>>(categoriesEntity);

        }

        public async Task<CategoryStockDto> GetCategoryById(int id)
        {
            var categoryEntityById = await _categoryRepository.GetCategoryById(id);
            return _mapper.Map<CategoryStockDto>(categoryEntityById);
        }

        public async Task RemoveCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetCategoryById(id).Result;
            await _categoryRepository.Delete(categoryEntity.CategoryId);
        }

        public async Task UpdateCategory(CategoryStockDto categoryDto)
        {
            var categoryEntity = _mapper.Map<CategoryStock>(categoryDto);
            await _categoryRepository.Update(categoryEntity);
        }
    }
}
