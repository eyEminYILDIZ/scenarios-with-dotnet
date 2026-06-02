using Microsoft.AspNetCore.Mvc;

namespace DistributedMemoryCache.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController(StudentCache cache, StudentDatabase db, ILogger<StudentController> logger) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var cached = await cache.GetAsync(id, ct);
        if (cached is not null)
        {
            logger.LogInformation("Cache hit for student {Id}", id);
            return Ok(cached);
        }

        logger.LogInformation("Cache miss for student {Id} - querying database", id);
        var student = db.GetStudentById(id);

        await cache.SetAsync(student, ct);
        return Ok(student);
    }
}
