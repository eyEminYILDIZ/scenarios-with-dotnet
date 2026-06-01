```

BenchmarkDotNet v0.15.8, Linux Ubuntu 24.04.4 LTS (Noble Numbat)
Intel Core i5-8250U CPU 1.60GHz (Max: 0.40GHz) (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.108
  [Host]     : .NET 10.0.8 (10.0.8, 10.0.826.23019), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.8 (10.0.8, 10.0.826.23019), X64 RyuJIT x86-64-v3


```
| Method              | Mean      | Error    | StdDev   | Rank | Gen0   | Allocated |
|-------------------- |----------:|---------:|---------:|-----:|-------:|----------:|
| GetYearWithDateTime | 244.28 ns | 1.238 ns | 1.097 ns |    2 |      - |         - |
| GetYearWithIndexing |  85.88 ns | 0.467 ns | 0.414 ns |    1 | 0.0509 |     160 B |
