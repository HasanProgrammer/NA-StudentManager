using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Student.Infra.Data.Sql.Commands.Common;

public class SQLContextFactory : IDesignTimeDbContextFactory<CommandDbContext>
{
    public CommandDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<CommandDbContext> builder = new DbContextOptionsBuilder<CommandDbContext>();
        
        builder.UseSqlServer("Somethings!");

        return new CommandDbContext(builder.Options);
    }
}