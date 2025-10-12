using System.Security.Cryptography;
using Courses.Models;
using Isopoh.Cryptography.Argon2;

namespace Courses.Tests.Factories;

public class UserFactory(AppDbContext dbContext)
{
    private const string ValidPassword = "example password";
    private static readonly string PasswordHash = Argon2.Hash(ValidPassword, 1, 16 * 1024);

    public User Create(Action<User> overrides = null)
    {
        var rand = Convert.ToHexStringLower(RandomNumberGenerator.GetBytes(3));
        var user = new User
        {
            Email = $"example-{rand}@example.com",
            GivenName = "Example",
            FamilyName = "User",
        };
    }
}