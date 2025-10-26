namespace Courses.Models;

public class Asset : IHasTimestamp
{
    public const string CdnBaseUrl = "https://d3n1g0yg3ja4p3.cloudfront.net";

    public Guid Id { get; set; } = Guid.CreateVersion7();

    public required string ObjectKey { get; set; }
    public string? OriginalFilename { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public string PublicUrl => Path.Join(CdnBaseUrl, ObjectKey);
}