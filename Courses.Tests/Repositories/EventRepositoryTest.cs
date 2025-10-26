using Courses.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses.Tests.Repositories;

[Collection("integration")]
public class EventRepositoryTest(GlobalTestFixture fixture) : DbTestBase(fixture)
{
    [Fact]
    public async Task Test_SelectEventListDto()
    {
        var pp = new Asset
        {
            ObjectKey = "cm7uqj3q500mglz8z2dqy8sdz.webp",
        };

        DbContext.Add(pp);
        await DbContext.SaveChangesAsync();

        var host1 = await Factory.CreateHost(h =>
        {
            h.FamilyName = "Host 1";
            h.ProfilePictureId = pp.Id;
        });
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
        var actualHost = actual.Hosts.First();
        Assert.Contains(pp.ObjectKey, actualHost.ProfilePictureUrl);
    }
}