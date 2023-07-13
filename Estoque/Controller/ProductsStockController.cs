using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            if (produtosDto == null)
                return NotFound("Nenhum produto cadastrado");
            return Ok(produtosDto);
        }
    }
}
