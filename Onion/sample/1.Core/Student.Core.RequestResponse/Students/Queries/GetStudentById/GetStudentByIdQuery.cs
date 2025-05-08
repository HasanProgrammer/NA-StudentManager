using Student.Core.RequestResponse.Student.DTOs;
using Zamin.Core.RequestResponse.Queries;

namespace Student.Core.RequestResponse.Student.Queries.GetStudentById;

public class GetStudentByIdQuery : IQuery<StudentDto?>
{
    public int Id { get; set; }
}