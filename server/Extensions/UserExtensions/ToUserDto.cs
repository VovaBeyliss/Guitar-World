using GuitarWorld.Models;
using GuitarWorld.Dtos;

namespace GuitarWorld.Extensions;

public static class UserExtensions {
    public static UserDto ToUserDto(this User source) => new UserDto(source.Username, source.Email, source.Password);
}