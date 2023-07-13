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
        public ProductsStockController(IProductsStockService productsService)
        {
            _productsService = productsService;
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
            if (productDto == null)
                return NotFound("Produto nao encontrado");
            await _productsService.Create(productDto);
            return productDto;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productsService.Delete(id);
            return Ok("Produto Deletado com sucesso");
        }
    }
}
