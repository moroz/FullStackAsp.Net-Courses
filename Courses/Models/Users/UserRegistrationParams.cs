using FluentValidation;
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

        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.Email).Matches(@"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,}$")
            .WithMessage("is not a valid email address");
        RuleFor(u => u.Email).MustAsync(BeUniqueEmail).WithMessage("has already been taken");
        RuleFor(u => u.GivenName).NotEmpty();
        RuleFor(u => u.FamilyName).NotEmpty();
        RuleFor(u => u.Password).Length(8, 128).Equal(u => u.PasswordConfirmation);
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return !await _dbContext.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }
}