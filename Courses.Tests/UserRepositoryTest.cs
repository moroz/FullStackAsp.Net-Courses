using Courses.Models;
using Courses.Repository;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests;

[Collection("integration")]
public class UserRepositoryTest(GlobalTestFixture fixture) : DbTestBase(fixture), IAsyncLifetime
{
    public new async Task InitializeAsync()
    {
        _scope = Fixture.AsyncScope;
        _dbContext = _scope?.ServiceProvider.GetRequiredService<AppDbContext>();

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
        await DbContext.Users.Where(u => u.Id == UserId).ExecuteDeleteAsync<User>();
        await DbContext.SaveChangesAsync();
        await Scope.DisposeAsync();
    }

    private AppDbContext? _dbContext;
    private AsyncServiceScope? _scope;
    private static readonly Guid UserId = Guid.CreateVersion7();

    private AppDbContext DbContext =>
        _dbContext ?? throw new InvalidOperationException("DbContext is not initialized");

    private AsyncServiceScope Scope => _scope ?? throw new InvalidOperationException("Scope is not initialized");

    private const string ValidPassword = "example password";
    private static readonly string PasswordHash = Argon2.Hash(ValidPassword, 1, 16 * 1024, 1);
    private const string Email = "user@example.com";

    [Theory]
    [InlineData(Email, ValidPassword, true)]
    [InlineData("User@Example.Com", ValidPassword, true)]
    [InlineData("uSeR@eXaMpLe.cOm", ValidPassword, true)]
    [InlineData(Email, "invalid", false)]
    [InlineData("invalid email", ValidPassword, false)]
    public async Task Test_AuthenticateUserByEmailPassword(string email, string password, bool valid)
    {
        var repo = Scope.ServiceProvider.GetRequiredService<IUserRepository>();
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