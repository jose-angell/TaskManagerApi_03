using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApi_03.Domain;

namespace TaskManagerApi_03.Infrastructure
{
    public class TaskConfiguration: IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.ToTable("tasks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(1000);
            builder.Property(t => t.Priority).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Status).IsRequired().HasMaxLength(50);
            builder.Property(t => t.DueDate).IsRequired();
            builder.Property(t => t.CreateAt).IsRequired();
            builder.HasOne(t => t.Employee)
                   .WithMany(e => e.Tasks)
                   .HasForeignKey(t => t.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
