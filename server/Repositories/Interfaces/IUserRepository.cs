using System.Linq.Expressions;
using System.Threading.Tasks;
using GuitarWorld.Models;

namespace GuitarWorld.Repositories.Interfaces;

public interface IUserRepository {
    Task<bool> UserExistsAsync(Expression<Func<User, bool>> predicate);
    Task AddUserAsync(User user);
    Task<User?> GetUserByIdAsync(int userId);
}