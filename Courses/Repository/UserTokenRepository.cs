using Courses.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses.Repository;

public class UserTokenRepository(AppDbContext dbContext)
{
    public async Task<UserToken> IssueAccessTokenForUser(User user, int validityInSeconds = 86400)
    {
        var now = DateTime.UtcNow;
        var token = new UserToken
        {
            Context = "access",
            UserId = user.Id,
            ValidUntil = now.AddSeconds(validityInSeconds),
            CreatedAt = now,
        };
        await dbContext.UserTokens.AddAsync(token);
        await dbContext.SaveChangesAsync();
        return token;
    }

    public async Task<User?> AuthenticateUserByAccessToken(byte[] token)
    {
        var now = DateTime.UtcNow;
        return await dbContext.Users
            .Join(dbContext.UserTokens,
                u => u.Id,
                t => t.UserId,
                (u, t) => new { u, t })
            .Where(x =>
                x.t.Context == "access" &&
                x.t.ValidUntil >= now &&
                x.t.Token == token)
            .Select(x => x.u)
            .FirstOrDefaultAsync();
    }
}