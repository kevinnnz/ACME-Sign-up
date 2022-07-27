using Microsoft.EntityFrameworkCore;
using Acme.Model;

namespace Acme.DAL
{
    public class AcmeDbContext : DbContext
    {

        public AcmeDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeActivity>().HasKey(ea => new { ea.EmployeeId, ea.ActivityId });
            modelBuilder.Entity<EmployeeActivity>().HasOne(ea => ea.Employee);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<EmployeeActivity> EmployeesActivities { get; set; }
    }
}
