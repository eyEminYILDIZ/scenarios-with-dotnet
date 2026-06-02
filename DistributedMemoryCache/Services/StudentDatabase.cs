using DistributedMemoryCache.Models;

namespace DistributedMemoryCache;

public class StudentDatabase
{
    private readonly string[] names = new string[] { "John", "Michael", "Khabib", "Richard", "Hussain", "Bill", "Dave" };
    private static int index = -1;
    public Student GetStudentById(Guid studentId)
    {
        return new Student()
        {
            Id = studentId,
            DisplayName = names[(++index) % names.Length],
            Gender = GenderTypes.Male,
        };
    }
}