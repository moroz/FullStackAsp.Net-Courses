using System.Net;
using Courses.Grpc;
using Courses.Repository;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests;

[Collection("integration")]
public class UnitTest1(GlobalTestFixture fixture) : DbTestBase(fixture)
{
    [Fact]
    public void Test_TheTruth()
    {
        var actual = 2 + 2;
        Assert.Equal(4, actual);
    }

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
        var client = Fixture.Factory.CreateDefaultClient();
        var response = await client.GetAsync("/");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Test_GrpcClient()
    {
        var client = Fixture.Factory.CreateDefaultClient();
        var channel = GrpcChannel.ForAddress(client.BaseAddress!, new GrpcChannelOptions { HttpClient = client, });
        var grpcClient = new CoursesApi.CoursesApiClient(channel);
        var actual = await grpcClient.ListEventsAsync(new ListEventsRequest());
        Assert.NotEmpty(actual.Events);
    }
}