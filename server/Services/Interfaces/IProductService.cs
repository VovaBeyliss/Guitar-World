namespace GuitarWorld.Services.Interfaces;

public interface IProductService {
    Task AddOrUpdateProductAsync(ProductDto dto, int userId);
    Task<List<ProductDto>> GetUserProductsAsync(int userId);
}