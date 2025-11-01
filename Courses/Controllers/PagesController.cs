using Courses.Repository;
using Courses.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Controllers;

public class PagesController(EventRepository repo) : Controller
{
    [HttpGet("/")]
    public async Task<IActionResult> Index()
    {
        var events = await repo.ListEvents();
        var model = new IndexViewModel { Events = events };
        return View(model);
    }
}