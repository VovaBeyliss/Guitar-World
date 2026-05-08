using GuitarWorld.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GuitarWorld.Models;
using GuitarWorld.Data;

public class UserRepository : IUserRepository {
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db) {
        _db = db;
    }

    public async Task<bool> UserExistsAsync(Expression<Func<User, bool>> predicate) {
        return await _db.Users.AnyAsync(predicate);
    }

    public async Task AddUserAsync(User user) {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task<User?> GetUserByIdAsync(int userId) {
        return await _db.Users.FindAsync(userId);
    }
}