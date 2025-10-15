using Courses.Models;
using Courses.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests.Repositories;

[Collection("integration")]
public class UserTokenRepositoryTest(GlobalTestFixture fixture) : DbTestBase(fixture), IAsyncLifetime
{
    [Fact]
    public async Task Test_IssueAccessTokenForUser()
    {
        var user = await Factory.CreateUser();
        var repo = new UserTokenRepository(DbContext);
        var actual = await repo.IssueAccessTokenForUser(user);
        Assert.NotNull(actual);
        Assert.IsType<UserToken>(actual);
        Assert.NotEmpty(actual.Token);
    }

    [Fact]
    public async Task Test_AuthenticateUserByAccessToken()
    {
        var user = await Factory.CreateUser();
        var repo = new UserTokenRepository(DbContext);
        var token = await repo.IssueAccessTokenForUser(user);
        Assert.NotNull(token);

        var actual = await repo.AuthenticateUserByAccessToken(token.Token);
        Assert.NotNull(actual);
        Assert.Equal(user.Id, actual.Id);
    }
}