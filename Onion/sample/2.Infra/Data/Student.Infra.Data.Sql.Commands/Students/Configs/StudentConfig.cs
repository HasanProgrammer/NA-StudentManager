using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Student.Infra.Data.Sql.Commands.Student.Configs;

public sealed class StudentConfig : IEntityTypeConfiguration<Core.Domain.Students.Entities.Student>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Students.Entities.Student> builder)
    {
        builder.ToTable("Students");
        
        builder.HasKey(student => student.Id);
            
        builder.HasIndex(student => new { student.CategoryId });
        
        builder.OwnsOne(student => student.Code)
               .Property(name => name.Value)
               .IsRequired()
               .HasMaxLength(10)
               .HasColumnName("Code");
        
        builder.OwnsOne(student => student.FirstName)
               .Property(name => name.Value)
               .IsRequired()
               .HasMaxLength(15)
               .HasColumnName("FirstName");
        
        builder.OwnsOne(student => student.LastName)
               .Property(name => name.Value)
               .IsRequired()
               .HasMaxLength(15)
               .HasColumnName("LastName");
        
        builder.Property(student => student.ImagePath).IsRequired(false);
        
        //relations
        
        builder.HasOne(student => student.Category)
               .WithMany(category => category.Students)
               .HasForeignKey(student => student.CategoryId);
    }
}