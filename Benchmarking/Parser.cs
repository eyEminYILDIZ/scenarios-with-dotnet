namespace Benchmarking;

public class Parser
{
    private readonly string _time;

    public Parser(string time)
    {
        _time = time;
    }

    public int GetYearWithDateTime(string time)
    {
        return DateTime.Parse(time).Year;
    }

    public int GetYearWithIndexing(string time)
    {
        return Convert.ToInt32(time.Split('-')[0]);
    }

}