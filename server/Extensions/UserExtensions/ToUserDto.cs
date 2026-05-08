using GuitarWorld.Models;
using GuitarWorld.Data;

namespace GuitarWorld.Extensions;

public static class UserExtensions {
    public static User ToUserDto(this UserDto dto) => new User(dto.UserName, dto.Email, dto.Password);
}