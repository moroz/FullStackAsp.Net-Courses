namespace Courses.Tests;

public class UnitTest1
{
    [Fact]
    public void Test_TheTruth()
    {
        var actual = 2 + 2;
        Assert.Equal(4, actual);
    }
}