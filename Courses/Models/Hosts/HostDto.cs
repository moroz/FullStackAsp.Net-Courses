namespace Courses.Models;

public class HostDto
{
    public Guid Id { get; set; }
    public string? Salutation { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? ProfilePictureUrl { get; set; }
}