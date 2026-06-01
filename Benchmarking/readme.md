# Benchmarking

This project created for demonstrating BenchmarkDotNet package usage in method benchmarking.

## How to run

Use commands below:
```sh
dotnet run -c Release
```

## Details

Created 2 methods for year extracting from a datetime string.

1. Method: GetYearWithDateTime
```c#
public int GetYearWithDateTime(string time)
{
    return DateTime.Parse(time).Year;
}
```


2. Method: GetYearWithIndexing
```c#
public int GetYearWithIndexing(string time)
{
    return Convert.ToInt32(time.Split('-')[0]);
}
```

## Results

| Method              | Mean      | Error    | StdDev   | Rank | Gen0   | Allocated |
|-------------------- |----------:|---------:|---------:|-----:|-------:|----------:|
| GetYearWithDateTime | 244.28 ns | 1.238 ns | 1.097 ns |    2 |      - |         - |
| GetYearWithIndexing |  85.88 ns | 0.467 ns | 0.414 ns |    1 | 0.0509 |     160 B |