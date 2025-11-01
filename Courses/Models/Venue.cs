using System.ComponentModel.DataAnnotations;

namespace Courses.Models;

public class Venue : IHasTimestamp
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    [StringLength(255)] public required string NameEn { get; set; }
    [StringLength(255)] public string? NamePl { get; set; }
    [StringLength(255)] public required string Street { get; set; }
    [StringLength(255)] public required string CityEn { get; set; }
    [StringLength(255)] public string? CityPl { get; set; }

    [StringLength(15)] public string? PostalCode { get; set; }

    [StringLength(2)] public required string CountryCode { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}