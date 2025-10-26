using Courses.Grpc;
using Google.Protobuf.WellKnownTypes;

namespace Courses.Models;

// DTO -- Data Transfer Object
public class EventListDto
{
    public Guid Id { get; set; }
    public required string TitleEn { get; set; }
    public required string TitlePl { get; set; }

    public IEnumerable<HostDto> Hosts { get; set; } = [];
    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsVirtual { get; set; }
    public required string DescriptionEn { get; set; }
    public required string DescriptionPl { get; set; }
    public required string Venue { get; set; }

    public Grpc.Event ToGrpcEvent()
    {
        var hosts = Hosts.Select(h => new Grpc.Host
        {
            Id = new UUID { Value = h.Id.ToString() },
            GivenName = h.GivenName,
            FamilyName = h.FamilyName,
            Salutation = h.Salutation,
            ProfilePictureUrl = h.ProfilePictureUrl,
        });

        return new Grpc.Event
        {
            TitleEn = TitleEn,
            TitlePl = TitlePl,
            StartsAt = Timestamp.FromDateTime(StartsAt),
            EndsAt = Timestamp.FromDateTime(EndsAt),
            CreatedAt = Timestamp.FromDateTime(CreatedAt),
            UpdatedAt = Timestamp.FromDateTime(UpdatedAt),
            IsVirtual = IsVirtual,
            DescriptionEn = DescriptionEn,
            DescriptionPl = DescriptionPl,
            Venue = Venue,
            Id = new UUID { Value = Id.ToString() },
            Hosts = { hosts }
        };
    }
}

public static class EventListDtoSelect
{
    public static IQueryable<EventListDto> MapEventToDto(this IQueryable<Event> events)
    {
        return events.Select(e => new EventListDto
        {
            Id = e.Id,
            TitleEn = e.TitleEn,
            TitlePl = e.TitlePl ?? "",
            StartsAt = e.StartsAt,
            EndsAt = e.EndsAt,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt,
            DescriptionEn = e.DescriptionEn,
            DescriptionPl = e.DescriptionPl ?? "",
            IsVirtual = e.IsVirtual,
            Venue = e.Venue ?? "",
            Hosts = e.EventHosts.OrderBy(eh => eh.Position).Select(eh => new
                HostDto
                {
                    FamilyName = eh.Host.FamilyName,
                    GivenName = eh.Host.GivenName,
                    Salutation = eh.Host.Salutation,
                    CreatedAt = eh.CreatedAt,
                    UpdatedAt = eh.UpdatedAt,
                    ProfilePictureUrl = eh.Host.ProfilePicture != null ? eh.Host.ProfilePicture.PublicUrl : null,
                }),
        });
    }
}