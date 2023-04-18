using ASPLabb1.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPLabb1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ASPLabb1DB;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");

        public DbSet<Employee> Employees => Set<Employee>();
    }
}
