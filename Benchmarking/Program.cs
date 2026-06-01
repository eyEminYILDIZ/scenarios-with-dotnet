namespace Benchmarking;

public class Program
{
    public static void Main(string[] args)
    {
        var time = "2026-06-01 09:00:21";
        var parser = new Parser(time);
        var yearWithDate = parser.GetYearWithDateTime(time);
        var yearWithIndex = parser.GetYearWithIndexing(time);

        System.Console.WriteLine($"With Date : {yearWithDate}");
        System.Console.WriteLine($"With Index: {yearWithIndex}");
    }
}