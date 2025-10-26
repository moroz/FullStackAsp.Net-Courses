using Courses.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses.Repository;

public class EventRepository(AppDbContext dbContext)
{
    public async Task<IEnumerable<EventListDto>> ListEvents()
    {
        return await dbContext.Events.AsNoTracking().OrderByDescending(e => e.StartsAt).MapEventToDto()
            .ToListAsync();
    }
}