using Microsoft.EntityFrameworkCore;

namespace Courses;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Models.Event> Events { get; set; }
    public DbSet<Models.User> Users { get; set; }
    public DbSet<Models.UserToken> UserTokens { get; set; }
}