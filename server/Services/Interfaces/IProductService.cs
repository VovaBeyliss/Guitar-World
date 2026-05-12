using System.Threading.Tasks;
using GuitarWorld.Dtos;

namespace GuitarWorld.Services.Interfaces;

public interface IProductService {
    Task AddOrUpdateProductAsync(AddProductDto dto, int userId);
    Task<List<GetProductDto>> GetUserProductsAsync(int userId);
}