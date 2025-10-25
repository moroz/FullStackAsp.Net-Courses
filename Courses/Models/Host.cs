using System.ComponentModel.DataAnnotations;

namespace Courses.Models;

public class Host : IHasTimestamp
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    [MaxLength(255)] public string? Salutation { get; set; }

    [MaxLength(255)] public required string GivenName { get; set; }

    [MaxLength(255)] public required string FamilyName { get; set; }

    public List<EventHost> EventHosts { get; } = [];
    public List<Event> Events { get; } = [];

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}