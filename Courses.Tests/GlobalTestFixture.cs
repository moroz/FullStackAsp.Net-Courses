using Courses.Grpc;

namespace Courses.Tests;

public class GlobalTestFixture : IAsyncLifetime
{
    private CustomWebApplicationFactory? _factory;
    private HttpClient? _client;
    private CoursesApi.CoursesApiClient? _apiClient;

    public CustomWebApplicationFactory Factory =>
        _factory ?? throw new InvalidOperationException("Factory is not initialized");

    public HttpClient Client => _client ?? throw new InvalidOperationException("Client is not initialized");

    public CoursesApi.CoursesApiClient ApiClient =>
        _apiClient ?? throw new InvalidOperationException("ApiClient is not initialized");

    public Task InitializeAsync()
    {
        _factory = new CustomWebApplicationFactory();
        _client = _factory.CreateDefaultClient();
        _apiClient = _factory.CreateApiClient();
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _factory?.Dispose();
        return Task.CompletedTask;
    }
}