using System;

namespace DistributedMemoryCache.Models;

public class Student
{
	public Guid Id { get; set; }
	public string DisplayName { get; set; }
	public string Age { get; set; }
	public GenderTypes Gender { get; set; }
}

public enum GenderTypes
{
	Male = 0,
	Female = 1,
}