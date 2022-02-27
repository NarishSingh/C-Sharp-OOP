namespace NewFeatures;

public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public static Quadrant GetQuadrant(Point point) =>
        point switch
        {
            (0, 0) => Quadrant.Origin,
            (> 0, > 0) => Quadrant.One,
            (< 0, > 0) => Quadrant.Two,
            (< 0, < 0) => Quadrant.Three,
            (> 0, < 0) => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };
}

public enum Quadrant
{
    Unknown,
    Origin,
    One,
    Two,
    Three,
    Four,
    OnBorder
}