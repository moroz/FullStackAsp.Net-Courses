using Courses.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests.Repositories;

[Collection("integration")]
public class UserTokenRepositoryTest(GlobalTestFixture fixture) : DbTestBase(fixture), IAsyncLifetime
{
    [Fact]
    public async Task Test_IssueAccessTokenForUser()
    {
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

        DbContext.Users.
    }
}