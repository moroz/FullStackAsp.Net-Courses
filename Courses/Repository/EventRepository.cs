using Microsoft.EntityFrameworkCore;

namespace Courses.Repository;

public class EventRepository(AppDbContext dbContext)
{
    public async Task<IEnumerable<Models.Event>> ListEvents()
    {
        return await dbContext.Events.AsNoTracking().OrderByDescending(e => e.StartsAt).ToListAsync();
    }
}