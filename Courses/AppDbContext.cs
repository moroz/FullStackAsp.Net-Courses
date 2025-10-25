using Courses.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Models.Event> Events { get; set; }
    public DbSet<Models.User> Users { get; set; }
    public DbSet<Models.UserToken> UserTokens { get; set; }
    public DbSet<Models.Host> Hosts { get; set; }

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
}