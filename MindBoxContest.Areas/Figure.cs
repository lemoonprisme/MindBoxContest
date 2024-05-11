namespace MindBoxContest.Areas;

public abstract class Figure 
{
    public abstract double Area { get; }

    internal abstract void Validate();
}