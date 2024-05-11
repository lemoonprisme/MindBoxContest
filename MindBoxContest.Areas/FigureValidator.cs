namespace MindBoxContest.Areas;

internal abstract class FigureValidator
{
    public bool IsValid { get; protected set; } = true;
    public List<string> Errors { get; } = new List<string>();

    public abstract bool Validate();
}