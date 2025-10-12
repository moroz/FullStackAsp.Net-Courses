using Microsoft.Extensions.DependencyInjection;

namespace Courses.Tests;

public abstract class DbTestBase(GlobalTestFixture fixture) : IAsyncLifetime
{
    protected readonly GlobalTestFixture Fixture = fixture;

    private AsyncServiceScope? _scope;

    protected AsyncServiceScope Scope => _scope ?? throw new InvalidOperationException("Scope is not initialized");
    protected AppDbContext DbContext => Scope.ServiceProvider.GetRequiredService<AppDbContext>();

    public Task InitializeAsync()
    {
        _scope = Fixture.AsyncScope;

        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await Scope.DisposeAsync();
    }
}