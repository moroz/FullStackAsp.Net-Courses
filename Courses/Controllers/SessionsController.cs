using Microsoft.AspNetCore.Mvc;

namespace Courses.Controllers;

public class SessionsController : Controller
{
    [HttpGet("/sign-in")]
    public IActionResult New()
    {
        return View();
    }
}