namespace MindBoxContest.Areas;

public class Circle : Figure
{
    public override double Area => Math.PI * Radius * Radius;
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
        Validate();
    }
    internal sealed override void Validate()
    {
        var validator = new CircleValidator(this);
        if (!validator.Validate())
            throw new ArgumentException(string.Join("\n", validator.Errors));
    }
}

internal class CircleValidator : FigureValidator
{
    private readonly Circle _circle;

    public CircleValidator(Circle circle)
    {
        _circle = circle;
    }

    public override bool Validate()
    {
        if (_circle.Radius <= 0.0)
        {
            IsValid = false;
            Errors.Add("Радиус должен быть больше либо равен нулю.");
        }

        return IsValid;
    }
}