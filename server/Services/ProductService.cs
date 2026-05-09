using GuitarWorld.Repositories.Interfaces;
using GuitarWorld.Services.Interfaces;
using GuitarWorld.Extensions;
using System.Threading.Tasks;
using GuitarWorld.Models;
using GuitarWorld.Dtos;

namespace GuitarWorld.Services;

public class ProductService : IProductService {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository) {
        _productRepository = productRepository;
    }

    public Task AddOrUpdateProductAsync(ProductDto dto, int userId) {
        var existingProduct = await _productRepository.GetProductByUserIdAndDetails(p => p.UserId == userId 
                                                                                      && p.Price == dto.Price 
                                                                                      && p.Name == dto.Name 
                                                                                      && p.Type == dto.Type 
                                                                                      && p.Brand == dto.Brand);

        if (existingProduct == null) {
            var newProduct = new Product {
                UserId = userId,
                Price = dto.Price,
                Name = dto.Name,
                Type = dto.Type,
                Brand = dto.Brand
            };

            await _productRepository.AddProductAsync(newProduct);
        } else {
            existingProduct.Quantity++;
            await _productRepository.UpdateProductAsync(existingProduct);
        }
    }

    public Task<List<ProductDto>> GetUserProductsAsync(int userId) {
        return (await _productRepository.GetProductsByUserIdAsync(userId)).Select(p => p.ToProductDto())
                                                                    .OrderByDescending(p => p.Quantity)
                                                                    .ToList();
    }
}