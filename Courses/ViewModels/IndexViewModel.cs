using Courses.Models;

namespace Courses.ViewModels;

public class IndexViewModel
{
    public IEnumerable<EventListDto> Events { get; set; } = [];
}