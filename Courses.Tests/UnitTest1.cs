using System.Net;
using Courses.Grpc;

namespace Courses.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var actual = 2 + 2;
        Assert.Equal(4, actual);
    }

    [Fact]
    public async Task Test_Setup()
    {
        var factory = new CustomWebApplicationFactory();
        var client = factory.CreateClient();
        var response = await client.GetAsync("/");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Test_Grpc()
    {
        var factory = new CustomWebApplicationFactory();
        var client = factory.CreateApiClient();
        var resp = await client.ListEventsAsync(new ListEventsRequest());
        Assert.Empty(resp.Events);
    }
}