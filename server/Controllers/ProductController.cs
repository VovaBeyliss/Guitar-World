using GuitarWorld.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GuitarWorld.Dtos;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase {
    private readonly IProductService _productService;

    public ProductController(IProductService productService) {
        _productService = productService;
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> AddpOrUpdateProduct([FromBody] ProductDto request, [FromRoute] int userId) {
        await _productService.AddpOrUpdateProduct(request, userId);

        return Ok(new { success = true });
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAllUserProducts([FromRoute] int userId) => Ok(new { success = true, products = await _productService.GetAllUserProductsAsync(userId) });
}