using Courses.Grpc;
using Courses.Models;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests;

public class GlobalTestFixture : IAsyncLifetime
{
    private WebApplicationFactory<Program>? _factory;

    public WebApplicationFactory<Program> WebFactory =>
        _factory ?? throw new InvalidOperationException("Factory is not initialized");

    public AsyncServiceScope AsyncScope => WebFactory.Services.CreateAsyncScope();

    public async Task InitializeAsync()
    {
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => builder.UseEnvironment("Test"));
        await MigrateDb();
        await SeedDb();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    private async Task MigrateDb()
    {
        await using var scope = AsyncScope;
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.MigrateAsync();
    }

    private async Task SeedDb()
    {
        await using var scope = AsyncScope;
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await Seeds.Run(db);
    }

    public CoursesApi.CoursesApiClient ApiClient()
    {
        var client = WebFactory.CreateDefaultClient();
        var channel = GrpcChannel.ForAddress(client.BaseAddress!, new GrpcChannelOptions
        {
            HttpClient = client,
        });
        return new CoursesApi.CoursesApiClient(channel);
    }
}