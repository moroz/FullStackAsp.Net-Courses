using System.Net;
using Courses.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests;

[Collection("integration")]
public class UnitTest1(GlobalTestFixture fixture) : DbTestBase(fixture)
{
    [Fact]
    public async Task Test_EventRepository()
    {
        await using var scope = Fixture.AsyncScope;
        var repo = scope.ServiceProvider.GetRequiredService<EventRepository>();
        var actual = await repo.ListEvents();
        Assert.NotEmpty(actual);
    }

    [Fact]
    public async Task Test_HttpClient()
    {
        var client = Fixture.WebFactory.CreateDefaultClient();
        var response = await client.GetAsync("/");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}