using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApi_03.Domain;

namespace TaskManagerApi_03.Infrastructure
{
    public class EmployeeConfiguration: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Department).IsRequired().HasMaxLength(100);
            builder.Property(e => e.IsActive).IsRequired();
            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}
