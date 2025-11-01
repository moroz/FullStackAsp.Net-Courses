using Courses.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Courses;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Models.Asset> Assets { get; set; }
    public DbSet<Models.Event> Events { get; set; }
    public DbSet<Models.Host> Hosts { get; set; }
    public DbSet<Models.User> Users { get; set; }
    public DbSet<Models.UserToken> UserTokens { get; set; }
    public DbSet<Models.Venue> Venues { get; set; }
    public DbSet<Models.EventPrice> EventPrices { get; set; }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<IHasTimestamp>())
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Models.Event>()
            .HasMany(e => e.Hosts)
            .WithMany(h => h.Events)
            .UsingEntity<EventHost>();

        modelBuilder.Entity<Models.Event>()
            .ToTable(t =>
            {
                t.HasCheckConstraint("event_base_price_must_have_currency",
                    "(base_price_amount is null) = (base_price_currency is null)");
            });

        modelBuilder.Entity<Models.EventPrice>()
            .ToTable(t =>
            {
                // Early bird prices must have a valid_until date
                t.HasCheckConstraint("event_price_early_bird_check",
                    "rule_type != 'early_bird' or valid_until is not null");
            });
    }

    public static void MapEnums(NpgsqlDbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .MapEnum<EventType>("event_type")
            .MapEnum<PriceRuleType>("price_rule_type")
            .MapEnum<PriceType>("price_type");
    }
}