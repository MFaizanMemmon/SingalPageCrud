using Microsoft.EntityFrameworkCore;
using SingalPageCrud.Models;

namespace SingalPageCrud.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-V6DB7O3\\SQLEXPRESS;database=SingalPageCrud;Trusted_Connection=True");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
