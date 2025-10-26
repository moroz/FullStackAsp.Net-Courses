using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Courses.Models;

public class Event : IHasTimestamp
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }

    [MaxLength(255)] public required string TitleEn { get; set; }
    [MaxLength(255)] public string? TitlePl { get; set; }

    public bool IsVirtual { get; set; }
    [MaxLength(255)] public string? Venue { get; set; }

    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    [MaxLength] public required string DescriptionEn { get; set; }

    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    [MaxLength] public string? DescriptionPl { get; set; }

    public List<EventHost> EventHosts { get; set; } = [];
    public List<Host> Hosts { get; } = [];

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}