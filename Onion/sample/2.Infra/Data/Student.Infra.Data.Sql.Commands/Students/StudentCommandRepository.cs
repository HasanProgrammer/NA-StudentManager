#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Student.Core.Contracts.Students.Commands;
using Student.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace Student.Infra.Data.Sql.Commands.Student.Configs;

public class StudentCommandRepository :
    BaseCommandRepository<Core.Domain.Students.Entities.Student, CommandDbContext, int>,
    IStudentCommandRepository
{
    public StudentCommandRepository(CommandDbContext dbContext) : base(dbContext){}

    public Task<TProjection> GetByIdProjectionally<TProjection>(int id,
        Expression<Func<Core.Domain.Students.Entities.Student, TProjection>> projection
    ) => _dbContext.Students.AsNoTracking().Select(projection).FirstOrDefaultAsync();

    public Task<List<TProjection>> GetAllWithPaginationProjectionally<TProjection>(
        int countPerPage, int pageNumber, Expression<Func<Core.Domain.Students.Entities.Student, TProjection>> projection
    ) => _dbContext.Students.AsNoTracking()
                            .Skip((pageNumber - 1)*countPerPage)
                            .Take(countPerPage)
                            .Select(projection)
                            .ToListAsync();
}