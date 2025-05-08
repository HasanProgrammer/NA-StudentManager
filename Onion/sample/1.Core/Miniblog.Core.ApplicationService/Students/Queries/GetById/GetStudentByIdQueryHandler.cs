using Student.Core.Contracts.Students.Commands;
using Student.Core.RequestResponse.Student.DTOs;
using Student.Core.RequestResponse.Student.Queries.GetStudentById;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Student.Core.ApplicationService.Students.Queries.GetById;

public class GetStudentByIdQueryHandler : QueryHandler<GetStudentByIdQuery, StudentDto?>
{
    private readonly IStudentCommandRepository _studentCommandRepository;

    public GetStudentByIdQueryHandler(
        ZaminServices zaminServices, IStudentCommandRepository studentCommandRepository
    ) : base(zaminServices)
    {
        _studentCommandRepository = studentCommandRepository;
    }

    public override async Task<QueryResult<StudentDto?>> Handle(GetStudentByIdQuery query)
    {
        var student = 
            await _studentCommandRepository.GetByIdProjectionally(query.Id, std => new StudentDto {
                Category = std.Category.Name,
                Code = std.Code.Value,
                FullName = std.FirstName.Value + " " + std.LastName.Value,
                ImagePath = std.ImagePath
            });

        return Result(student);
    }
}