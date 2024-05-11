namespace MindBoxContest.Areas.Extension;

public static class DoubleExtension
{
    public static bool NearlyEqual(this double x, double y, double epsilon)
    {
        const double minNormal = 2.2250738585072014E-308d;
        double absA = Math.Abs(x);
        double absB = Math.Abs(y);
        double diff = Math.Abs(x - y);

        if (x.Equals(y))
        {
            return true;
        }

        if (x == 0 || y == 0 || absA + absB < minNormal) 
        {
            return diff < (epsilon * minNormal);
        }
            
        return diff / (absA + absB) < epsilon;
    }
}