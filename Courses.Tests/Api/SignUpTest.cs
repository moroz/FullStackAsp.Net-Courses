using Courses.Grpc;
using Microsoft.EntityFrameworkCore;

namespace Courses.Tests.Api;

[Collection("integration")]
public class SignUpTest(GlobalTestFixture fixture) : DbTestBase(fixture)
{
    [Fact]
    public async Task Test_SignUpWithValidParams()
    {
        var request = new UserRegistrationRequest
        {
            Email = TestFactory.UniqueEmail(),
            Password = TestFactory.ValidPassword,
            PasswordConfirmation = TestFactory.ValidPassword,
            GivenName = "Example",
            FamilyName = "User"
        };

        var client = Fixture.ApiClient();
        var actual = await client.RegisterUserAsync(request);
        Assert.True(actual.Success);
        var user = actual.User;
        Assert.NotNull(user);
        Assert.Equal(request.Email, user.Email);
        Assert.Equal(request.GivenName, user.GivenName);
        Assert.Equal(request.FamilyName, user.FamilyName);
        var dbUser = await DbContext.Users.SingleOrDefaultAsync(u => u.Email == request.Email);
        Assert.NotNull(dbUser);
        Assert.True(dbUser.IsValidPassword(request.Password));
    }

    [Theory]
    [InlineData("invalid@email", TestFactory.ValidPassword, TestFactory.ValidPassword, "Example", "User")]
    public async Task Test_SignUpWithInvalidParams(string email, string password, string confirmation, string givenName,
        string familyName)
    {
        var request = new UserRegistrationRequest
        {
            Email = email,
            Password = password,
            PasswordConfirmation = confirmation,
            GivenName = givenName,
            FamilyName = familyName
        };

        var client = Fixture.ApiClient();
        var actual = await client.RegisterUserAsync(request);
        Assert.False(actual.Success);
    }
}