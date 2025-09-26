using Courses.Grpc;

namespace Courses.Tests;

public abstract class DbTestBase(GlobalTestFixture fixture) : IAsyncLifetime
{
    protected readonly GlobalTestFixture Fixture = fixture;
    protected HttpClient HttpClient => Fixture.Client;
    protected CoursesApi.CoursesApiClient ApiClient => Fixture.ApiClient;

    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public virtual Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}