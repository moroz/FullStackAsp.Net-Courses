using Grpc.Core;
using Courses.Grpc;
using Courses.Repository;
using Google.Protobuf.WellKnownTypes;

namespace Courses.Services;

public class CoursesService(ILogger<GreeterService> logger, IEventRepository eventRepository) : CoursesApi.CoursesApiBase
{
    private readonly ILogger<GreeterService> _logger = logger;

    public override async Task<ListEventsResponse> ListEvents(ListEventsRequest request, ServerCallContext context)
    {
        var events = await eventRepository.ListEvents();
        var list = new List<Event>();
        
        foreach (var e in events)
        {
            list.Add(new Event
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
                Id = new UUID
                {
                    Value = e.Id.ToString()
                }
            });
        }

        return new ListEventsResponse
        {
            Events =
            {
                list
            }
        };
    }
}