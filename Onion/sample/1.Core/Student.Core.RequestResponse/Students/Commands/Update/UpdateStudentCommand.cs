
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;

namespace Student.Core.RequestResponse.Student.Commands.Update;

public class UpdateStudentCommand : ICommand, IWebRequest
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;

    public string Path => "/api/Student/Update";
}