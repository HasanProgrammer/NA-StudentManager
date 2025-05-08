using Student.Core.RequestResponse.Category.DTOs;
using Zamin.Core.RequestResponse.Queries;

namespace Student.Core.RequestResponse.Category.Queries.GetStudentById;

public class GetCategoryByIdQuery : IQuery<CategoryDto?>
{
    public int Id { get; set; }
}