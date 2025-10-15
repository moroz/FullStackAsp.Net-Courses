using Courses.Models;
using Courses.Repository;

namespace Courses.Middleware;

public class AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context, UserTokenRepository repo)
    {
        var header = context.Request.Headers["Authorization"].FirstOrDefault();

        User? user = null;

        if (!string.IsNullOrEmpty(header) && header.StartsWith("Bearer "))
        {
            try
            {
                var token = Convert.FromBase64String(header["Bearer ".Length..].Trim());
                user = await repo.AuthenticateUserByAccessToken(token);
                if (user != null)
                {
                    logger.LogDebug("User {UserId} authenticated successfully.", user.Id);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error during authentication");
            }
        }

        context.Items["CurrentUser"] = user;

        await next(context);
    }
}