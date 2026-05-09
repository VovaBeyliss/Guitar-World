using GuitarWorld.Repositories.Services;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GuitarWorld.Models;

namespace GuitarWorld.Repositories;

public class ProductRepository : IProductRepository {
    private readonly AppDbContext _db;   

    public UserService(AppDbContext db) {
        _db = db;
    }

    public async Task<Product?> GetProductByUserIdAndDetails(Expression<Func<Product, bool>> predicate) => await _db.Products.FirstOrDefaultAsync(predicate);

    public async Task AddProductAsync(Product product) {
        await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product) {
        _db.Products.Update(product);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllProductsByUserIdAsync(int userId) => await _db.Products.Where(p => p.UserId == userId).ToListAsync();
}