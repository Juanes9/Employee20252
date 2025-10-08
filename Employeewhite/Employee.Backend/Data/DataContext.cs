using Microsoft.EntityFrameworkCore;
using Employee.shared.Entities;

namespace Employee.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<EmployeeBD> Employees => Set<EmployeeBD>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeBD>().HasIndex(c => c.Id).IsUnique();
        }
    }
}