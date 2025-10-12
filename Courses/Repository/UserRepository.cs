using Courses.Models;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;

namespace Courses.Repository;

public class UserRepository(AppDbContext dbContext)
{
    public async Task<User?> AuthenticateUserByEmailPassword(string email, string password)
    {
        var user = await dbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        if (user == null)
        {
            return null;
        }

        if (Argon2.Verify(user.PasswordHash, password))
        {
            return user;
        }

        return null;
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await dbContext.Users.FindAsync(id);
    }
}