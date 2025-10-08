using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests;

public class GlobalTestFixture : IAsyncLifetime
{
    private WebApplicationFactory<Program>? _factory;

    public WebApplicationFactory<Program> Factory =>
        _factory ?? throw new InvalidOperationException("Factory is not initialized");

    public AsyncServiceScope AsyncScope => Factory.Services.CreateAsyncScope();

    public async Task InitializeAsync()
    {
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => builder.UseEnvironment("Test"));
        await MigrateDb();
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
}