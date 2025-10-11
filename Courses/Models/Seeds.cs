using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;

namespace Courses.Models;

public static class Seeds
{
    public static async Task Run(AppDbContext db)
    {
        await db.Events.ExecuteDeleteAsync();
        await db.Users.ExecuteDeleteAsync();

        var events = new List<Event>
        {
            new Event
            {
                Id = new Guid("0199c2f2-528b-7e88-96e3-5e5088333a8c"),
                TitleEn = "To Perfect the Art of Homeopathy",
                DescriptionEn =
                    "Dr. Sanjay Modi, former professor of Mumbai Homeopathic College. The webinar is organised in honorary cooperation with the Polish Homeopathic Society and the Polish Society of Homeopathic Doctors and Pharmacists.",
                StartsAt = DateTime.Parse("2025-05-30T14:00:00Z").ToUniversalTime(),
                EndsAt = DateTime.Parse("2025-05-31T08:00:00Z").ToUniversalTime(),
                IsVirtual = true,
                Venue = "Poznań, Hotel IOR"
            },
            new Event
            {
                Id = new Guid("0199c2fa-7e9d-72f6-ada1-88b5d04d9a58"),
                TitleEn = "Perfect the Art of Homeopathy 2",
                TitlePl = "Udoskonalić kunszt homeopatyczny 2",
                StartsAt = DateTime.Parse("2025-10-24T14:00:00Z").ToUniversalTime(),
                EndsAt = DateTime.Parse("2025-10-26T11:30:00Z").ToUniversalTime(),
                DescriptionEn =
                    "Dr. Sanjay Modi, former professor of Mumbai Homeopathic College. The webinar is organised in honorary cooperation with the Polish Homeopathic Society and the Polish Society of Homeopathic Doctors and Pharmacists.\n\nOctober 24-25 2025, Vienna House Easy By Wyndham Cracow ul. Przy Rondzie 2, Kraków, Poland.\n\nOnline mode will also available (through Zoom). The lectures will be held in English with consecutive translation to Polish.",
                Venue = "Kraków, Poland",
                IsVirtual = true
            }
        };

        await db.Events.AddRangeAsync(events);

        await db.Users.AddAsync(new User
        {
            Id = new Guid("0199d410-cbcd-7407-8cab-cca22fbf2e4d"),
            Email = "hs@moroz.dev",
            Country = "TW",
            PasswordHash = Argon2.Hash("foobar"),
            GivenName = "Karol",
            FamilyName = "Moroz",
        });

        await db.SaveChangesAsync();
    }
}