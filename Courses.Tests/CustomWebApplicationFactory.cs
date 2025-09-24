using Courses.Grpc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Grpc.Net.Client;

namespace Courses.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");

        builder.ConfigureServices(services =>
        {
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
        });
    }

    private GrpcChannel CreateGrpcChannel()
    {
        var client = CreateDefaultClient();
        return GrpcChannel.ForAddress(client.BaseAddress!, new GrpcChannelOptions
        {
            HttpClient = client,
        });
    }

    public CoursesApi.CoursesApiClient CreateApiClient()
    {
        var channel = CreateGrpcChannel();
        return new CoursesApi.CoursesApiClient(channel);
    }
}