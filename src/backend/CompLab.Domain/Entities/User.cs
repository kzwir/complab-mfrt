namespace CompLab.Domain.Entities;

public sealed class User
{
    public Guid UserId { get; private set; }

    public string Email { get; private set; } = string.Empty;

    public string PasswordHash { get; private set; } = string.Empty;

    public string Role { get; private set; } = string.Empty;

    private User()
    {
    }

    public User(
        Guid userId,
        string email,
        string passwordHash,
        string role)
    {
        UserId = userId;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }
}
