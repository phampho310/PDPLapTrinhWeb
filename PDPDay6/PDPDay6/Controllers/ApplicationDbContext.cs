using PDPDay6.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PDPDay6.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
