#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Student.Core.RequestResponse.Category.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}