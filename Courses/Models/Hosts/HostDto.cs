namespace Courses.Models;

public class HostDto
{
    public Guid Id { get; set; }
    public string? Salutation { get; set; }
    public required string GivenName { get; set; }
    public required string FamilyName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? ProfilePictureUrl { get; set; }
}