#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Student.Core.RequestResponse.Student.DTOs;

public class StudentDto
{
    public string Category { get; set; }
    public string Code { get; set; }
    public string FullName { get; set; }
    public string ImagePath { get; set; }
}