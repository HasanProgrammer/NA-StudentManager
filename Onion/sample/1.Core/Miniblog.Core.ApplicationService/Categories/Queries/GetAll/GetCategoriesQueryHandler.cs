using Student.Core.Contracts.Students.Commands;
using Student.Core.RequestResponse.Category.DTOs;
using Student.Core.RequestResponse.Category.Queries.GetAll;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Student.Core.ApplicationService.Categories.Queries.GetAll;

public class GetStudentsQueryHandler : QueryHandler<GetAllQuery, List<CategoryDto>>
{
    private readonly ICategoryCommandRepository _categoryCommandRepository;

    public GetStudentsQueryHandler(
        ZaminServices zaminServices, ICategoryCommandRepository categoryCommandRepository
    ) : base(zaminServices)
    {
        _categoryCommandRepository = categoryCommandRepository;
    }

    public override async Task<QueryResult<List<CategoryDto>>> Handle(GetAllQuery query)
    {
        var categories =
            await _categoryCommandRepository.GetAllWithPaginationProjectionally(
                query.PageSize, query.PageNumber, category => new CategoryDto {
                    Id = category.Id,
                    Name = category.Name
                }
            );

        return Result(categories);
    }
}