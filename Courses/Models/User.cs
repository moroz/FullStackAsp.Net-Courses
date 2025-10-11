using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Courses.Models;

public class User
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    [Column(TypeName = "citext")]
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [StringLength(10)] public string? Salutation { get; set; }

    [StringLength(255)] [Required] public required string GivenName { get; set; }
    [StringLength(255)] [Required] public required string FamilyName { get; set; }

    public string? Country { get; set; }
    [StringLength(255)] public string? Profession { get; set; }
    [StringLength(255)] public string? Organization { get; set; }
    [StringLength(255)] public string? Company { get; set; }

    [StringLength(255)] public string? PasswordHash { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastLoginAt { get; set; }
    public IPAddress? LastLoginIp { get; set; }
}