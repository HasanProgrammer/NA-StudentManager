using Student.Core.RequestResponse.Category.DTOs;
using Student.Core.RequestResponse.Category.Queries.GetStudentById;
using Student.Core.Contracts.Students.Commands;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Student.Core.ApplicationService.Categories.Queries.GetById;

public class GetCategoryByIdQueryHandler : QueryHandler<GetCategoryByIdQuery, CategoryDto?>
{
    private readonly ICategoryCommandRepository _categoryCommandRepository;

    public GetCategoryByIdQueryHandler(
        ZaminServices zaminServices, ICategoryCommandRepository categoryCommandRepository
    ) : base(zaminServices)
    {
        _categoryCommandRepository = categoryCommandRepository;
    }

    public override async Task<QueryResult<CategoryDto?>> Handle(GetCategoryByIdQuery query)
    {
        var student = 
            await _categoryCommandRepository.GetByIdProjectionally(query.Id, category => new CategoryDto {
                Id = category.Id,
                Name = category.Name
            });

        return Result(student);
    }
}