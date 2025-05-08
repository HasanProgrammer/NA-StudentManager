#pragma warning disable CS8604 // Possible null reference argument.

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace Student.Infra.Data.Sql.Commands.Common
{
    public class CommandDbContext : BaseOutboxCommandDbContext
    {
        public DbSet<Core.Domain.Students.Entities.Category> Categories { get; set; }
        public DbSet<Core.Domain.Students.Entities.Student> Students { get; set; }
        
        public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(CommandDbContext)));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
