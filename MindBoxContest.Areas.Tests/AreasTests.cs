using MindBoxContest.Areas.Extension;

namespace MindBoxContest.Areas.Tests;

public class AreasTests
{
    [Theory]
    [InlineData(1.0, Math.PI)]
    [InlineData(2.342, 17.231523)]
    public void GetCircleArea_ValidRadius_ReturnsArea(double radius, double expectedArea)
    {
        var circle = new Circle(radius);
        Assert.Equal(expectedArea, circle.Area, 6);
    }

    [Fact]
    public void GetCircleArea_NegativeRadius_ThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Circle(-1.0));
    }

    [Theory]
    [InlineData(1.0, 1.0, 1.0, 0.433013)]
    [InlineData(7.32, 5, 5, 12.467875)]
    [InlineData(5, 7.32, 5, 12.467875)]
    [InlineData(5, 5, 7.32, 12.467875)]
    public void GetTriangleArea_ValidSides_ReturnsArea(double a, double b, double c, double expectedArea)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Equal(expectedArea, triangle.Area, 6);
    }

    [Theory]
    [InlineData(-1.0, 1.0, 1.0)]
    [InlineData(1.0, 1.0, 5.0)]
    public void GetTriangleArea_InvalidSides_ReturnsArea(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }
}