using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;

namespace Courses.Models;

public static class Seeds
{
    public static async Task Run(AppDbContext db)
    {
        await db.Events.ExecuteDeleteAsync();
        await db.Users.ExecuteDeleteAsync();
        await db.Hosts.ExecuteDeleteAsync();
        await db.Assets.ExecuteDeleteAsync();

        var profilePicture = new Asset
        {
            ObjectKey = "cm7uqj3q500mglz8z2dqy8sdz.webp",
            OriginalFilename = "cm7uqj3q500mglz8z2dqy8sdz.webp"
        };
        db.Add(profilePicture);

        var modi = new Host
        {
            Salutation = "common.hosts.salutation.dr",
            GivenName = "Sanjay",
            FamilyName = "Modi",
            ProfilePictureId = profilePicture.Id,
        };
        db.Add(modi);

        var viennaHouse = new Venue
        {
            NameEn = "Vienna House Easy By Wyndham Cracow",
            CityEn = "Cracow",
            CityPl = "Kraków",
            CountryCode = "PL",
            Street = "ul. Przy Rondzie 2",
        };
        db.Add(viennaHouse);

        var ior = new Venue
        {
            NameEn = "IOR Hotel",
            NamePl = "Hotel IOR",
            CityEn = "Poznań",
            CountryCode = "PL",
            Street = "ul. Węgorka 20",
            PostalCode = "60-318"
        };
        db.Add(ior);

        List<Event> events =
        [
            new()
            {
                Id = new Guid("0199c2f2-528b-7e88-96e3-5e5088333a8c"),
                TitleEn = "To Perfect the Art of Homeopathy",
                DescriptionEn =
                    "Dr. Sanjay Modi, former professor of Mumbai Homeopathic College. The webinar is organised in honorary cooperation with the Polish Homeopathic Society and the Polish Society of Homeopathic Doctors and Pharmacists.",
                StartsAt = DateTime.Parse("2025-05-30T14:00:00Z").ToUniversalTime(),
                EndsAt = DateTime.Parse("2025-05-31T08:00:00Z").ToUniversalTime(),
                IsVirtual = true,
                Venue = ior,
            },

            new()
            {
                Id = new Guid("0199c2fa-7e9d-72f6-ada1-88b5d04d9a58"),
                TitleEn = "Perfect the Art of Homeopathy 2",
                TitlePl = "Udoskonalić kunszt homeopatyczny 2",
                StartsAt = DateTime.Parse("2025-10-24T14:00:00Z").ToUniversalTime(),
                EndsAt = DateTime.Parse("2025-10-26T11:30:00Z").ToUniversalTime(),
                DescriptionEn =
                    "Dr. Sanjay Modi, former professor of Mumbai Homeopathic College. The webinar is organised in honorary cooperation with the Polish Homeopathic Society and the Polish Society of Homeopathic Doctors and Pharmacists.\n\nOctober 24-25 2025, Vienna House Easy By Wyndham Cracow ul. Przy Rondzie 2, Kraków, Poland.\n\nOnline mode will also available (through Zoom). The lectures will be held in English with consecutive translation to Polish.",
                Venue = viennaHouse,
                IsVirtual = true
            }
        ];

        events[0].EventHosts = new List<EventHost>
        {
            new EventHost
            {
                HostId = modi.Id,
                EventId = events[0].Id,
                Position = 0
            }
        };
        events[1].EventHosts = new List<EventHost>
        {
            new EventHost
            {
                HostId = modi.Id,
                EventId = events[1].Id,
                Position = 0,
            }
        };

        db.Events.AddRange(events);

        await db.Users.AddAsync(new User
        {
            Id = new Guid("0199d410-cbcd-7407-8cab-cca22fbf2e4d"),
            Email = "hs@moroz.dev",
            Country = "TW",
            Password = "foobar",
            GivenName = "Karol",
            FamilyName = "Moroz",
        });

        await db.SaveChangesAsync();
    }
}