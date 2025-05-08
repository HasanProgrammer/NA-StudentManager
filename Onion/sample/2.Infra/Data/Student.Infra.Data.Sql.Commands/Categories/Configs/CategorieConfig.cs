using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Student.Infra.Data.Sql.Commands.Categories.Configs;

public sealed class CategoryConfig : IEntityTypeConfiguration<Core.Domain.Students.Entities.Category>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Students.Entities.Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(category => category.Id);
            
        builder.HasIndex(category => new { category.Name });

        builder.Property(category => category.Name).HasMaxLength(20);
        
        //relations
        
        builder.HasMany(category => category.Students)
               .WithOne(student => student.Category)
               .HasForeignKey(student => student.CategoryId);
                
    }
}