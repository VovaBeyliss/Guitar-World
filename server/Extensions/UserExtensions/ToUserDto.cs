using GuitarWorld.Models;
using GuitarWorld.Data;

namespace GuitarWorld.Extensions;

public static class UserExtensions {
    public static UserDto ToUserDto(this User user) => new User(user.UserName, user.Email, user.Password);
}