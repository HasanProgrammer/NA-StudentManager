using Student.Core.Contracts.Students.Commands;
using Student.Core.RequestResponse.Student.Queries.GetAll;
using Student.Core.RequestResponse.Student.DTOs;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Student.Core.ApplicationService.Students.Queries.GetAll;

public class GetStudentsQueryHandler : QueryHandler<GetAllQuery, List<StudentDto>>
{
    private readonly IStudentCommandRepository _studentCommandRepository;

    public GetStudentsQueryHandler(
        ZaminServices zaminServices, IStudentCommandRepository studentCommandRepository
    ) : base(zaminServices)
    {
        _studentCommandRepository = studentCommandRepository;
    }

    public override async Task<QueryResult<List<StudentDto>>> Handle(GetAllQuery query)
    {
        var students =
            await _studentCommandRepository.GetAllWithPaginationProjectionally(
                query.PageSize, query.PageNumber, std => new StudentDto {
                Category = std.Category.Name,
                Code = std.Code.Value,
                FullName = std.FirstName.Value + " " + std.LastName.Value,
                ImagePath = std.ImagePath
            });

        return Result(students);
    }
}