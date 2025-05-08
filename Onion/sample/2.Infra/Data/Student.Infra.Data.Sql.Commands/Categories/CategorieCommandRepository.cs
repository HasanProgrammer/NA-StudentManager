#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Student.Core.Contracts.Students.Commands;
using Student.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace Student.Infra.Data.Sql.Commands.Categories.Configs;

public class CategoryCommandRepository :
    BaseCommandRepository<Core.Domain.Students.Entities.Category, CommandDbContext, int>,
    ICategoryCommandRepository
{
    public CategoryCommandRepository(CommandDbContext dbContext) : base(dbContext){}

    public Task<TProjection> GetByIdProjectionally<TProjection>(int id,
        Expression<Func<Core.Domain.Students.Entities.Category, TProjection>> projection
    ) => _dbContext.Categories.AsNoTracking().Select(projection).FirstOrDefaultAsync();

    public Task<List<TProjection>> GetAllWithPaginationProjectionally<TProjection>(
        int countPerPage, int pageNumber, Expression<Func<Core.Domain.Students.Entities.Category, TProjection>> projection
    ) => _dbContext.Categories.AsNoTracking()
                              .Skip((pageNumber - 1)*countPerPage)
                              .Take(countPerPage)
                              .Select(projection)
                              .ToListAsync();
}