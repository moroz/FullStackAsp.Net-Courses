using System.Security.Cryptography;
using System.Text;
using Courses.Models;
using Courses.Services;
using Microsoft.AspNetCore.Authentication;

namespace Courses.Tests.Services;

public class SessionServiceTest
{
    private const string SecretKeyBase =
        "jKeZVSULHKgV1REKtw6YZTzurg6/t/uGHdL8pctRizuvPSdnvpYtSVwSWmQ5MJuGtR2sXnT312YQqR/bFJCCKA==";

    [Fact]
    public void Test_Constructor()
    {
        var exc = Record.Exception(() => { _ = new SessionService(SecretKeyBase); });
        Assert.Null(exc);
    }

    [InlineData("Hello world!")]
    [InlineData("")]
    [Theory]
    public void Test_SealAndOpenString(string payload)
    {
        var service = new SessionService(SecretKeyBase);
        var actual = service.Seal(payload);
        var decoded = Base64UrlTextEncoder.Decode(actual);
        Assert.Equal(payload.Length + SessionService.Overhead, decoded.Length);

        var opened = service.Open(actual);
        Assert.NotNull(opened);
        var text = Encoding.UTF8.GetString(opened);
        Assert.Equal(payload, text);
    }

    [Fact]
    public void Test_SealAndOpenBinary()
    {
        var service = new SessionService(SecretKeyBase);
        var payload = new byte[] { 42, 12, 35, 18, 29 };
        var actual = service.Seal(payload);
        var decoded = Base64UrlTextEncoder.Decode(actual);
        Assert.Equal(payload.Length + SessionService.Overhead, decoded.Length);

        var opened = service.Open(actual);
        Assert.NotNull(opened);
        Assert.Equal(payload, opened);
    }

    [Fact]
    public void Test_EncodeSessionData()
    {
        var service = new SessionService(SecretKeyBase);
        var token = RandomNumberGenerator.GetBytes(32);
        var payload = new SessionData { UserToken = token };
        var actual = service.EncodeAndSeal(payload);
        var ok = service.DecodeCookie(actual, out SessionData? decoded);
        Assert.True(ok);
        Assert.NotNull(decoded);
        Assert.Equal(payload.UserToken, decoded.UserToken);
        Assert.Null(decoded.PreferredLocale);
    }
}