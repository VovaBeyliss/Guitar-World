using System.Linq.Expressions;

namespace GuitarWorld.Repositories.Interfaces;

public interface IProductRepository {
    Task<Product?> GetProductByUserIdAndDetails(Expression<Func<Product, bool>> predicate);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task<List<Product>> GetAllProductsByUserIdAsync(int userId);
}