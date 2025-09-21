using Google.Protobuf.Collections;
using Grpc.Core;

namespace Courses.Services;

public class CoursesService(ILogger<GreeterService> logger) : CoursesApi.CoursesApiBase
{
    private readonly ILogger<GreeterService> _logger = logger;

    public override Task<ListEventsResponse> ListEvents(ListEventsRequest request, ServerCallContext context)
    {
        var list = new List<Event>();

        list.Add(new Event
        {
            TitleEn = "Hello world!",
            TitlePl = "Something",
            Id = new UUID
            {
                Value = Guid.CreateVersion7().ToString(),
            }
        });

        return Task.FromResult(new ListEventsResponse
        {
            Events =
            {
                list
            }
        });
    }
}