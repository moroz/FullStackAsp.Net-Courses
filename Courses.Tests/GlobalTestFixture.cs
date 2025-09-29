using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests;

public class GlobalTestFixture : IAsyncLifetime
{
    private CustomWebApplicationFactory? _factory;

    public CustomWebApplicationFactory Factory =>
        _factory ?? throw new InvalidOperationException("Factory is not initialized");

    public async Task InitializeAsync()
    {
        _factory = new CustomWebApplicationFactory();
        await _factory.Migrate();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}