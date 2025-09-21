using Courses.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; }
}