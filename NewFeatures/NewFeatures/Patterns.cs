namespace NewFeatures;

public static class Patterns
{
    public static bool IsLetter(this char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

    //parenthesized
    public static bool IsLetterOrSeparator(this char c) =>
        c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';
}