namespace Courses.Models;

public class Asset : IHasTimestamp
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public required string ObjectKey { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}