using System.Linq.Expressions;
using Zamin.Core.Contracts.Data.Commands;

namespace Student.Core.Contracts.Students.Commands;

//کامندها و کوئری رو ها رو در این قسمت هندل میکنم ( برای عدم پیچیده شدن ساختار و تاپیک بروکر )
public interface ICategoryCommandRepository : ICommandRepository<Domain.Students.Entities.Category, int>
{
    Task<TProjection> GetByIdProjectionally<TProjection>(int id,
        Expression<Func<Domain.Students.Entities.Category, TProjection>> projection
    );
    
    Task<List<TProjection>> GetAllWithPaginationProjectionally<TProjection>(
        int countPerPage, int pageNumber, Expression<Func<Domain.Students.Entities.Category, TProjection>> projection
    );
}