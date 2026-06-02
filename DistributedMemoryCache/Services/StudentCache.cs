using System.Text.Json;
using DistributedMemoryCache.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace DistributedMemoryCache;

public class StudentCache(IDistributedCache cache)
{
    private static readonly DistributedCacheEntryOptions _options = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
    };

    private static string Key(Guid id) => $"distributedmemorycache:student:{id}";

    public async Task SetAsync(Student student, CancellationToken ct = default)
    {
        var json = JsonSerializer.SerializeToUtf8Bytes(student);
        await cache.SetAsync(Key(student.Id), json, _options, ct);
    }

    public async Task<Student?> GetAsync(Guid id, CancellationToken ct = default)
    {
        var bytes = await cache.GetAsync(Key(id), ct);
        return bytes is null ? null : JsonSerializer.Deserialize<Student>(bytes);
    }
}
