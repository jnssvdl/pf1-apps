using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gender>().HasData(new Gender { GenderId = "M", GenderName = "Male"}, new Gender { GenderId = "F", GenderName = "Female" });

            modelBuilder.Entity<Department>().HasData(new Department { DepartmentCode = "FIN", DepartmentName = "Finance" }, new Department { DepartmentCode = "HR", DepartmentName = "Human Resources" }, new Department { DepartmentCode = "DT", DepartmentName = "Digital Transformation" });
        }
    }
}
