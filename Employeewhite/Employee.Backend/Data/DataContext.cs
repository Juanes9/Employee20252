using Microsoft.EntityFrameworkCore;
using Employee.shared.Entities;

namespace Employee.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<EmployeeBD> Employees { get; set; }

        // Para crear index y evitar repeticiones de nombres de los tipos de categorias
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}