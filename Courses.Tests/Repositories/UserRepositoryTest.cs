using Courses.Models;
using Courses.Repository;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests.Repositories;

[Collection("integration")]
public class UserRepositoryTest(GlobalTestFixture fixture) : DbTestBase(fixture), IAsyncLifetime
{
    private User? _user;
    private User User => _user ?? throw new InvalidOperationException("User is not initialized");

    public new async Task InitializeAsync()
    {
        await base.InitializeAsync();
        _user = await Factory.CreateUser(u => { u.Email = "user@example.com"; });
    }

    public new async Task DisposeAsync()
    {
        await DbContext.Users.Where(u => u.Id == User.Id).ExecuteDeleteAsync();
        await base.DisposeAsync();
    }

    private const string Email = "user@example.com";

    [Theory]
    [InlineData(Email, TestFactory.ValidPassword, true)]
    [InlineData("User@Example.Com", TestFactory.ValidPassword, true)]
    [InlineData("uSeR@eXaMpLe.cOm", TestFactory.ValidPassword, true)]
    [InlineData(Email, "invalid", false)]
    [InlineData("invalid email", TestFactory.ValidPassword, false)]
    public async Task Test_AuthenticateUserByEmailPassword(string email, string password, bool valid)
    {
        var repo = Scope.ServiceProvider.GetRequiredService<UserRepository>();
        var actual = await repo.AuthenticateUserByEmailPassword(email, password);

        if (valid)
        {
            Assert.NotNull(actual);
            Assert.Equal(User.Id, actual.Id);
        }
        else
        {
            Assert.Null(actual);
        }
    }
}