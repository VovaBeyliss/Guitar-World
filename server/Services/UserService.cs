using GuitarWorld.Repositories.Interfaces;
using GuitarWorld.Services.Interfaces;
using GuitarWorld.Extensions;
using System.Threading.Tasks;
using GuitarWorld.Models;
using GuitarWorld.Dtos;

namespace GuitarWorld.Services;

public class UserService : IUserService {
    private readonly IUserRepository _userRepository;   

    public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<bool> AddUserAsync(UserDto dto) {
        var userExists = await _userRepository.UserExistsAsync(user => user.Username == dto.Username && 
                                                                  user.Email == dto.Email && 
                                                                  user.Password == dto.Password);

        if (!userExists) {
            var newUser = new User {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password
            };

            await _userRepository.AddUserAsync(newUser);

            return true;
        }

        return false;
    }

    public async Task<bool> UserExistsAsync(UserDto dto) {
        return await _userRepository.UserExistsAsync(user => user.Username == dto.Username && 
                                                                  user.Email == dto.Email && 
                                                                  user.Password == dto.Password);
    }

    public async Task<UserDto?> GetUserAsync(int userId) => (await _userRepository.GetUserByIdAsync(userId))?.ToUserDto();
}