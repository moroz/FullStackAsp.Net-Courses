using Grpc.Core;
using Courses.Grpc;
using Courses.Repository;
using Google.Protobuf.WellKnownTypes;

namespace Courses.Services;

public partial class CoursesService(ILogger<CoursesService> logger, AppDbContext dbContext)
    : CoursesApi.CoursesApiBase
{
    private readonly ILogger<CoursesService> _logger = logger;

    public override async Task<ListEventsResponse> ListEvents(ListEventsRequest request, ServerCallContext context)
    {
        var repo = new EventRepository(dbContext);
        var events = await repo.ListEvents();
        var list = events.Select(e => e.ToGrpcEvent());

        return new ListEventsResponse
        {
            Events =
            {
                list
            }
        };
    }
}