using System.Threading.Tasks;
using GuitarWorld.Dtos;

namespace GuitarWorld.Services.Interfaces;

public class IUserService {
    Task<bool> AddUserAsync(UserDto dto);
    Task<bool> UserExistsAsync(UserDto dto);
    Task<UserDto?> GetUserAsync(int userId);
}