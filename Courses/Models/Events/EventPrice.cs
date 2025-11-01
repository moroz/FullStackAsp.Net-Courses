using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses.Models;

public enum PriceType
{
    Fixed,
    Percentage,
    DiscountFixed,
    DiscountPercentage
}

public enum PriceRuleType
{
    Base,
    DiscountCode,
    EarlyBird,
}

public class EventPrice : IHasTimestamp
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;

    public PriceType PriceType { get; set; } = PriceType.Fixed;
    public PriceRuleType RuleType { get; set; } = PriceRuleType.Base;

    [Column(TypeName = "decimal(20, 8)")] public decimal PriceAmount { get; set; }
    [StringLength(3)] public string PriceCurrency { get; set; } = "PLN";

    public int Priority { get; set; } = 0;
    public bool IsActive { get; set; } = true;

    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidUntil { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}