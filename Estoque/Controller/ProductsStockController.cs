using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsStockController : ControllerBase
    {
        private readonly IProductsStockService _productsService;
        private readonly ICategoryStockService _categoryService;
        public ProductsStockController(IProductsStockService productsService, ICategoryStockService categoryService)
        {
            _productsService = productsService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductStockDto>>> Get()
        {
            var produtosDto = await _productsService.GetAll();
            if (!produtosDto.Any() | produtosDto == null)
                return NotFound("Nenhum produto cadastrado");
            return Ok(produtosDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductStockDto>> GetById(int id)
        {
            var produtoDto = await _productsService.GetProductById(id);
            if (produtoDto == null)
                return NotFound("Produto nao encontrado");
            return produtoDto;
        }

        [HttpPost]
        public async Task<ActionResult<ProductStockDto>> Post([FromBody] ProductStockDto productDto)
        {
            if(productDto.CategoryId == null)
            {
                return NotFound("CategoryId não informado.");
            }
            var checkCategoryId = await _categoryService.GetCategoryById(productDto.CategoryId);
            if (checkCategoryId is null)
            {
                return NotFound(" A Categoria que está sendo feita a inclusão do produto não existe, tente com uma CategoryId válida.");
            }
            if (productDto == null)
                return NotFound("Produto nao encontrado");
            await _productsService.Create(productDto);
            return Ok("Produto adicionado com sucesso.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productsService.Delete(id);
            return Ok("Produto Deletado com sucesso");
        }
    }
}
