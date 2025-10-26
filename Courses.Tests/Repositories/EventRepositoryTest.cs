using Courses.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses.Tests.Repositories;

[Collection("integration")]
public class EventRepositoryTest(GlobalTestFixture fixture) : DbTestBase(fixture)
{
    [Fact]
    public async Task Test_SelectEventListDto()
    {
        var host1 = await Factory.CreateHost(h => h.FamilyName = "Host 1");
        var host2 = await Factory.CreateHost(h => h.FamilyName = "Host 2");

        var event1 = new Event
        {
            TitleEn = "Test",
            DescriptionEn = "Test",
            StartsAt = DateTime.UtcNow,
            EndsAt = DateTime.UtcNow.AddSeconds(3600),
        };

        event1.EventHosts =
        [
            new EventHost
            {
                EventId = event1.Id,
                HostId = host1.Id,
                Position = 0,
            },

            new EventHost
            {
                EventId = event1.Id,
                HostId = host2.Id,
                Position = 1
            }
        ];

        DbContext.Add(event1);
        await DbContext.SaveChangesAsync();

        var events = await DbContext.Events.MapEventToDto().ToListAsync();
        var actual = events.Find(e => e.Id == event1.Id);
        Assert.NotNull(actual);
        Assert.Equal(2, actual.Hosts.Count());
    }
}