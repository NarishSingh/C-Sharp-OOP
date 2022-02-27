namespace NewFeatures;

public class UsingWriter
{
    public static int WriteLinesTofile(IEnumerable<string> lines)
    {
        using var file = new StreamWriter("WriteLines.txt");

        int skipped = 0;
        foreach (string line in lines)
        {
            if (!line.Contains("Second")) file.WriteLine(line);
            else skipped++;
        }

        return skipped;
        //file var disposed here
    }
}