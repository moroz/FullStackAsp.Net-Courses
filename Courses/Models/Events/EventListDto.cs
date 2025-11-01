namespace Courses.Models;

// DTO -- Data Transfer Object
public class EventListDto
{
    public Guid Id { get; set; }
    public required string TitleEn { get; set; }
    public required string TitlePl { get; set; }
    public required EventType EventType { get; set; }

    public IEnumerable<HostDto> Hosts { get; set; } = [];
    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsVirtual { get; set; }
    public required string DescriptionEn { get; set; }
    public required string DescriptionPl { get; set; }
    public Venue? Venue { get; set; }
    public IEnumerable<EventPrice> Prices { get; set; } = [];
    public string? BasePriceCurrency { get; set; }
    public decimal? BasePriceAmount { get; set; }
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
            EventType = e.EventType,
            IsVirtual = e.IsVirtual,
            Venue = e.Venue,
            Prices = e.Prices,
            BasePriceAmount = e.BasePriceAmount,
            BasePriceCurrency = e.BasePriceCurrency,
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