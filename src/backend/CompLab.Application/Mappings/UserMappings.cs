using CompLab.Application.DTOs.Users;
using CompLab.Domain.Entities;

namespace CompLab.Application.Mappings;

public static class UserMappings
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            UserId = user.UserId,
            Email = user.Email,
            Role = user.Role
        };
    }

    public static List<UserDto> ToDtoList(
        this IEnumerable<User> users)
    {
        return users
            .Select(x => x.ToDto())
            .ToList();
    }
}
