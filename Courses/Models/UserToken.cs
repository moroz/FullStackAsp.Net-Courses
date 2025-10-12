using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Courses.Models;

[Index(nameof(ValidUntil))]
[Index(nameof(CreatedAt))]
[Index(nameof(Token), IsUnique = true)]
public class UserToken
{
    public const int TokenLength = 32;

    [Key] public Guid Id { get; set; }
    [ForeignKey("users")] public Guid UserId { get; set; }
    public User? User { get; set; }

    [StringLength(255)] public required string Context { get; set; }

    public byte[] Token { get; set; } = RandomNumberGenerator.GetBytes(TokenLength);

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ValidUntil { get; set; }
}