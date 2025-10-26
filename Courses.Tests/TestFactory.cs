using System.Security.Cryptography;
using Courses.Models;
using Isopoh.Cryptography.Argon2;

namespace Courses.Tests;

public class TestFactory(AppDbContext dbContext)
{
    public const string ValidPassword = "example password";
    private static readonly string PasswordHash = Argon2.Hash(ValidPassword, 1, 16 * 1024);

    public static string UniqueEmail()
    {
        var rand = Convert.ToHexStringLower(RandomNumberGenerator.GetBytes(3));
        return $"example-{rand}@example.com";
    }

    public async Task<User> CreateUser(Action<User>? overrides = null)
    {
        var user = new User
        {
            Email = UniqueEmail(),
            GivenName = "Example",
            FamilyName = "User",
            PasswordHash = PasswordHash,
        };

        overrides?.Invoke(user);

        dbContext.Add(user);
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<Host> CreateHost(Action<Host>? overrides = null)
    {
        var host = new Host
        {
            GivenName = "John",
            FamilyName = "Doe",
            Salutation = "Dr.",
        };

        overrides?.Invoke(host);

        dbContext.Add(host);
        await dbContext.SaveChangesAsync();
        return host;
    }
}