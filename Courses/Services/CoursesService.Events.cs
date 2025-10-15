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
        var list = events.Select(e => new Event
            {
                TitleEn = e.TitleEn,
                TitlePl = e.TitlePl,
                StartsAt = Timestamp.FromDateTime(e.StartsAt),
                EndsAt = Timestamp.FromDateTime(e.EndsAt),
                CreatedAt = Timestamp.FromDateTime(e.CreatedAt),
                UpdatedAt = Timestamp.FromDateTime(e.UpdatedAt),
                IsVirtual = e.IsVirtual,
                DescriptionEn = e.DescriptionEn,
                DescriptionPl = e.DescriptionPl,
                Venue = e.Venue,
                Id = new UUID { Value = e.Id.ToString() }
            })
            .ToList();

        return new ListEventsResponse
        {
            Events =
            {
                list
            }
        };
    }
}