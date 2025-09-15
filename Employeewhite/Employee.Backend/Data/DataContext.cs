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
    }
}