using BenchmarkDotNet.Attributes;

namespace Benchmarking;

[MemoryDiagnoser]
[RankColumn]
public class ParserBenchmarks
{
    private const string Time = "2026-06-01 09:00:21";
    private readonly Parser _parser = new(Time);

    [Benchmark]
    public int GetYearWithDateTime() => _parser.GetYearWithDateTime(Time);

    [Benchmark]
    public int GetYearWithIndexing() => _parser.GetYearWithIndexing(Time);
}
