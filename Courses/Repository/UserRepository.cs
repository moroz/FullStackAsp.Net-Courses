using Courses.Models;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;

namespace Courses.Repository;

public class UserRepository(AppDbContext dbContext)
{
    public async Task<User?> AuthenticateUserByEmailPassword(string email, string password)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        if (user != null && user.IsValidPassword(password)) return user;
        return null;
    }

    public async Task<(User?, ValidationResult?)> RegisterUser(UserRegistrationParams request)
    {
        var validator = new UserRegistrationParamsValidator(dbContext);
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid) return (null, result);

        var user = new User
        {
            Email = request.Email,
            Password = request.Password,
            GivenName = request.GivenName,
            FamilyName = request.FamilyName
        };

        dbContext.Add(user);
        await dbContext.SaveChangesAsync();

        return (user, result);
    }
}