using PDPDay5Lab_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace PDPDay5Lab_Model.Models

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
