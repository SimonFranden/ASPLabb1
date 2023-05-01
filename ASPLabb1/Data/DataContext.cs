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

        public DbSet<ASPLabb1.Models.VacationApplication> VacationApplication { get; set; } = default!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FName="TestEmp1", LName="TestEmp1"},
                new Employee { EmployeeId = 2, FName = "TestEmp2", LName = "TestEmp2" },
                new Employee { EmployeeId = 3, FName = "TestEmp3", LName = "TestEmp3" }

            );
        }

        

        public DbSet<ASPLabb1.Models.ApplicationInfoViewmodel> ApplicationInfoViewmodel { get; set; } = default!;
    }
}
