using Courses.Models;
using Grpc.Core;

namespace Courses.Middleware;

public static class HttpContextExtensions
{
    public static User? GetCurrentUser(this HttpContext context)
    {
        if (context.Items.TryGetValue("CurrentUser", out var user) && user != null)
        {
            return user as User;
        }

        return null;
    }
}

public static class ServerCallContextExtensions
{
    public static User? GetCurrentUser(this ServerCallContext context)
    {
        return context.GetHttpContext().GetCurrentUser();
    }
}