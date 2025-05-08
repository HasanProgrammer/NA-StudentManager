namespace MiniBlog.Endpoints.API.DTOs;

public class CreateStudentDto
{
    public int CategoryId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
}