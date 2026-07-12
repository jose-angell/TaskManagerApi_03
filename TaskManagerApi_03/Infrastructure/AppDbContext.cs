using Microsoft.EntityFrameworkCore;
using TaskManagerApi_03.Domain;

namespace TaskManagerApi_03.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Domain.Task> Tasks => Set<Domain.Task>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
