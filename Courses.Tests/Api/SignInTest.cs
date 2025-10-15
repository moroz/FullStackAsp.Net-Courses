using Courses.Grpc;
using Microsoft.EntityFrameworkCore;

namespace Courses.Tests.Api;

[Collection("integration")]
public class SignInTest(GlobalTestFixture fixture) : DbTestBase(fixture)
{
    [Theory]
    [InlineData("sign_in@example.com", TestFactory.ValidPassword, true)]
    [InlineData("sIgN_In@eXaMpLe.com", TestFactory.ValidPassword, true)]
    [InlineData("SIGN_IN@EXAMPLE.COM", TestFactory.ValidPassword, true)]
    [InlineData("INVALID@EXAMPLE.COM", TestFactory.ValidPassword, false)]
    [InlineData("invalid@example.com", TestFactory.ValidPassword, false)]
    public async Task Test_SignInWithPassword(string email, string password, bool valid)
    {
        await DbContext.Users.ExecuteDeleteAsync();
        var user = await Factory.CreateUser(u => u.Email = "sign_in@example.com");
        Assert.NotNull(user);

        var client = Fixture.ApiClient();
        var result = await client.SignInWithPasswordAsync(new SignInWithPasswordRequest
        {
            Email = email,
            Password = password,
        });

        Assert.Equal(valid, result.Success);
        if (valid)
        {
            Assert.NotEmpty(result.AccessToken.ToByteArray());
            Assert.Empty(result.Errors);
        }
        else
        {
            Assert.Empty(result.AccessToken.ToByteArray());
            Assert.NotEmpty(result.Errors);
        }
    }
}