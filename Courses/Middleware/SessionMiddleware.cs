using Courses.Models;
using Courses.Repository;
using Courses.Services;

namespace Courses.Middleware;

public class SessionMiddleware(RequestDelegate next, ILogger<SessionMiddleware> logger, SessionService sessionService)
{
    private const string SessionCookieName = "_courses_session";

    public async Task InvokeAsync(HttpContext context, UserTokenRepository repo)
    {
        var cookie = context.Request.Cookies[SessionCookieName];

        User? user = null;
        SessionData? sessionData = null;

        if (!string.IsNullOrEmpty(cookie))
        {
            try
            {
                var ok = sessionService.DecodeCookie(cookie, out sessionData);
                if (sessionData != null)
                {
                    user = await repo.AuthenticateUserByAccessToken(sessionData.UserToken);
                }

                if (user != null)
                {
                    logger.LogDebug("User {UserId} authenticated successfully.", user.Id);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error decoding session cookie");
            }
        }

        context.Items["CurrentUser"] = user;
        context.Items["Session"] = sessionData;

        await next(context);
    }
}