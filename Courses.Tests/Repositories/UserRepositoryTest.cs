using Courses.Models;
using Courses.Repository;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests.Repositories;

[Collection("integration")]
public class UserRepositoryTest(GlobalTestFixture fixture) : DbTestBase(fixture), IAsyncLifetime
{
    public new async Task InitializeAsync()
    {
        await base.InitializeAsync();

        var user = new User
        {
            Id = UserId,
            Email = Email,
            GivenName = "Example",
            FamilyName = "User",
            PasswordHash = PasswordHash,
        };
        await DbContext.Users.AddAsync(user);
        await DbContext.SaveChangesAsync();
    }

    public new async Task DisposeAsync()
    {
        await DbContext.Users.Where(u => u.Id == UserId).ExecuteDeleteAsync();
        await DbContext.SaveChangesAsync();
        await base.DisposeAsync();
    }

    private static readonly Guid UserId = Guid.CreateVersion7();

    private const string ValidPassword = "example password";
    private static readonly string PasswordHash = Argon2.Hash(ValidPassword, 1, 16 * 1024);
    private const string Email = "user@example.com";

    [Theory]
    [InlineData(Email, ValidPassword, true)]
    [InlineData("User@Example.Com", ValidPassword, true)]
    [InlineData("uSeR@eXaMpLe.cOm", ValidPassword, true)]
    [InlineData(Email, "invalid", false)]
    [InlineData("invalid email", ValidPassword, false)]
    public async Task Test_AuthenticateUserByEmailPassword(string email, string password, bool valid)
    {
        var repo = Scope.ServiceProvider.GetRequiredService<UserRepository>();
        var actual = await repo.AuthenticateUserByEmailPassword(email, password);

        if (valid)
        {
            Assert.NotNull(actual);
            Assert.Equal(UserId, actual.Id);
        }
        else
        {
            Assert.Null(actual);
        }
    }
}