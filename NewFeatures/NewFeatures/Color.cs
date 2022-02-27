namespace NewFeatures;

public enum Rainbow
{
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Indigo,
    Violet
}

public class RgbColor
{
    private byte _r;
    private byte _g;
    private byte _b;

    public RgbColor(byte r, byte g, byte b)
    {
        _r = r;
        _g = g;
        _b = b;
    }

    public static RgbColor FromRainbow(Rainbow colorBand) =>
        colorBand switch
        {
            Rainbow.Red => new RgbColor(0xFF, 0x00, 0x00),
            Rainbow.Orange => new RgbColor(0xFF, 0x7F, 0x00),
            Rainbow.Yellow => new RgbColor(0xFF, 0xFF, 0x00),
            Rainbow.Green => new RgbColor(0x00, 0xFF, 0x00),
            Rainbow.Blue => new RgbColor(0x00, 0x00, 0xFF),
            Rainbow.Indigo => new RgbColor(0x4B, 0x00, 0x82),
            Rainbow.Violet => new RgbColor(0x94, 0x00, 0xD3),
            _ => throw new ArgumentException("invalid enum value", nameof(colorBand))
        }; //default becomes the discard operator

    public override string ToString() => $"RBG: ({_r}, {_g}, {_b})";
}