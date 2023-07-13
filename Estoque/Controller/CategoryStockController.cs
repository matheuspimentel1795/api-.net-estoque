using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryStockController : ControllerBase
    {
        private readonly ICategoryStockService _categoryService;
        public CategoryStockController(ICategoryStockService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryStockDto>>> Get()
        {
            var categoryDto = await _categoryService.GetCategories();
            if (categoryDto is null)
                return NotFound();
            return Ok(categoryDto);
        }
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryStockDto>> Get(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto is null)
                return NotFound("Categoria não encontrada.");
            return Ok(categoryDto);
        }
        [HttpPost]
        public async Task<ActionResult<CategoryStockPayloadDto>> Post([FromBody] CategoryStockPayloadDto categoryDto)
        {
            if (categoryDto is null)
                return NotFound("payload inválido.");
            await _categoryService.AddCategory(categoryDto);
            return Ok(categoryDto);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryStockPayloadDto>> EditCategory(int id, [FromBody] CategoryStockPayloadDto categoryDto)
        {
            if (categoryDto is null)
                return NotFound("payload inválido.");

            var checkId = await _categoryService.GetCategoryById(id);
            if (checkId is null)
            {
                return NotFound("Categoria não encontrada.");
            }
            CategoryStockDto payload = new CategoryStockDto
            {
                CategoryId = id,
                Name = categoryDto.Name,
            };
            await _categoryService.UpdateCategory(payload);
            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> DeleteCategory(int id)
        {
            var checkId = await _categoryService.GetCategoryById(id);
            if (checkId is null)
            {
                return NotFound("Categoria não encontrada.");
            }
            await _categoryService.RemoveCategory(id);
            return Ok("Categoria deletada com sucesso");
        }
    }
}
