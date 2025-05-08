using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;

namespace Student.Core.RequestResponse.Student.Commands.Create;

public class CreateStudentCommand : ICommand<bool>, IWebRequest
{
    public int CategoryId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;

    public string Path => "/api/Student/Create";
}