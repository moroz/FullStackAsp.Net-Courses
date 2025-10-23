using Courses.Models;
using Courses.Repository;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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

    [Fact]
    public async Task Test_RegisterUser()
    {
        var repo = new UserRepository(DbContext);
        var request = new UserRegistrationParams
        {
            Email = "valid@example.com",
            GivenName = "Example",
            FamilyName = "User",
            Password = "foobar2000",
            PasswordConfirmation = "foobar2000"
        };
        var (user, result) = await repo.RegisterUser(request);
        Assert.NotNull(user);
        Assert.NotNull(result);
        Assert.True(result.IsValid);
        Assert.True(await DbContext.Users.Where(u => u.Email == request.Email).AnyAsync());
        Assert.Equal(request.Email, user.Email);
        Assert.Equal(request.GivenName, user.GivenName);
        Assert.Equal(request.FamilyName, user.FamilyName);
        Assert.StartsWith("$argon2id$", user.PasswordHash);
        Assert.True(user.IsValidPassword(request.Password));
    }

    [Theory]
    [InlineData("invalid@email", "foobar2000", "foobar2000")]
    [InlineData("valid-email@example.com", "foobar2000", "does not match")]
    [InlineData("valid-email@example.com", "short", "short")]
    public async Task Test_RegisterUserWithInvalidParams(string email, string password, string confirmation)
    {
        var repo = new UserRepository(DbContext);
        var request = new UserRegistrationParams
        {
            Email = email,
            GivenName = "Example",
            FamilyName = "User",
            Password = password,
            PasswordConfirmation = confirmation
        };

        var (user, validationResult) = await repo.RegisterUser(request);
        Assert.Null(user);
        Assert.NotNull(validationResult);
        Assert.False(validationResult.IsValid);
        Assert.NotEmpty(validationResult.Errors);
    }

    [Fact]
    public async Task Test_RegisterUserWithDuplicateEmail()
    {
        var existing = await Factory.CreateUser();
        var request = new UserRegistrationParams
        {
            Email = existing.Email,
            Password = TestFactory.ValidPassword,
            PasswordConfirmation = TestFactory.ValidPassword,
            GivenName = "Example",
            FamilyName = "User"
        };

        var repo = new UserRepository(DbContext);
        var (user, validationResult) = await repo.RegisterUser(request);
        Assert.Null(user);
        Assert.NotNull(validationResult);
        Assert.False(validationResult.IsValid);
        Assert.NotEmpty(validationResult.Errors);
        Assert.Equal("Email", validationResult.Errors.First().PropertyName);
    }
}