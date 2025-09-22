using Microsoft.EntityFrameworkCore;

namespace Courses.Repository;

public interface IEventRepository
{
    Task<IEnumerable<Models.Event>> ListEvents();
}

public class EventRepository(AppDbContext dbContext) : IEventRepository
{
    public async Task<IEnumerable<Models.Event>> ListEvents()
    {
        return await dbContext.Events.AsNoTracking().OrderByDescending(e => e.StartsAt).ToListAsync();
    }
}