using landscape_be.models;
using Microsoft.EntityFrameworkCore;

namespace landscape_be.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Database=Landscape;TrustServerCertificate=true;Trusted_Connection=True;");
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
