using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Courses.Models;

[Table("events_hosts")]
[Index(nameof(EventId), nameof(HostId), IsUnique = true)]
[Index(nameof(EventId), nameof(Position), IsUnique = true)]
public class EventHost : IHasTimestamp
{
    [Key] public Guid Id { get; set; } = Guid.CreateVersion7();

    [ForeignKey("event_id")] public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;

    [ForeignKey("host_id")] public Guid HostId { get; set; }
    public Host Host { get; set; } = null!;

    public int Position { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
