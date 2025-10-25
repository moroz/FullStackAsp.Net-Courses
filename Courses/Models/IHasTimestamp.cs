namespace Courses.Models;

public interface IHasTimestamp
{
    DateTime UpdatedAt { get; set; }
}