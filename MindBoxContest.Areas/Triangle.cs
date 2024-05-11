using MindBoxContest.Areas.Extension;

namespace MindBoxContest.Areas;

public class Triangle : Figure
{
    public bool IsRight => (A * A + B * B).NearlyEqual(C * C, C / 10e6);
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(double a, double b, double c)
    {
        var sides = new List<double>() { a, b, c };
        sides.Sort();
        A = sides[0];
        B = sides[1];
        C = sides[2];
        Validate();
    }
    
    public override double Area
    {
        get
        {
            var p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }

    internal sealed override void Validate()
    {
        var validator = new TriangleValidator(this);
        if (!validator.Validate())
        {
            throw new ArgumentException(string.Join("\n", validator.Errors));
        }
    }
    
}
internal class TriangleValidator : FigureValidator
{
    private readonly Triangle _triangle;

    public TriangleValidator(Triangle triangle)
    {
        _triangle = triangle;
    }

    public override bool Validate()
    {
        var sides = new List<double>() { _triangle.A, _triangle.B, _triangle.C };
        if (sides.Any(side => side <= 0))
        {
            IsValid = false;
            Errors.Add("Все стороны должны быть положительными.");
        }
        if (_triangle.C >= _triangle.A + _triangle.B)
        {
            IsValid = false;
            Errors.Add("Треугольник существует только тогда, когда сумма двух его сторон больше третьей.");
        }
            
        return IsValid;
    }
}