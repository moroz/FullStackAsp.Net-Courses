using Microsoft.EntityFrameworkCore;

namespace Courses;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}