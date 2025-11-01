using Courses.Grpc;
using Google.Protobuf.WellKnownTypes;
using Decimal = Courses.Grpc.Decimal;

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

        var prices = Prices.Select(p => new Grpc.EventPrice
        {
            Id = new UUID { Value = p.Id.ToString() },
            PriceAmount = p.PriceAmount.ToGrpcDecimal(),
            PriceCurrency = p.PriceCurrency,
            PriceType = (Grpc.PriceType)p.PriceType,
            Priority = p.Priority,
            ValidUntil = p.ValidUntil != null ? Timestamp.FromDateTime((DateTime)p.ValidUntil) : null,
            ValidFrom = p.ValidFrom != null ? Timestamp.FromDateTime((DateTime)p.ValidFrom) : null,
            CreatedAt = Timestamp.FromDateTime(p.CreatedAt),
            UpdatedAt = Timestamp.FromDateTime(p.UpdatedAt),
            IsActive = p.IsActive,
            RuleType = (Grpc.PriceRuleType)p.RuleType,
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
            Venue = Venue?.ToGrpcVenue(),
            Id = new UUID { Value = Id.ToString() },
            Prices = { prices },
            Hosts = { hosts },
            EventType = (Grpc.EventType)EventType,
            BasePriceAmount = BasePriceAmount?.ToGrpcDecimal(),
            BasePriceCurrency = BasePriceCurrency,
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