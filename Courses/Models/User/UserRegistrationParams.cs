using FluentValidation;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;

namespace Courses.Models;

public class UserRegistrationParams
{
    public required string Email { get; set; }
    public required string GivenName { get; set; }
    public required string FamilyName { get; set; }
    public required string Password { get; set; }
    public required string PasswordConfirmation { get; set; }
}

public class UserRegistrationParamsValidator : AbstractValidator<UserRegistrationParams>
{
    private readonly AppDbContext _dbContext;

    public UserRegistrationParamsValidator(AppDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(u => u.Email).Matches(@"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,}$").NotEmpty().MustAsync(BeUniqueEmail);
        RuleFor(u => u.GivenName).NotNull();
        RuleFor(u => u.FamilyName).NotNull();
        RuleFor(u => u.Password).Length(8, 128).Equal(u => u.PasswordConfirmation);
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return !await _dbContext.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }
}