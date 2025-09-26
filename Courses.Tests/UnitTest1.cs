using System.Net;
using Courses.Grpc;

namespace Courses.Tests;

[Collection("integration")]
public class UnitTest1(GlobalTestFixture fixture) : DbTestBase(fixture)
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
        var response = await HttpClient.GetAsync("/");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Test_Grpc()
    {
        var resp = await ApiClient.ListEventsAsync(new ListEventsRequest());
        Assert.Empty(resp.Events);
    }
}