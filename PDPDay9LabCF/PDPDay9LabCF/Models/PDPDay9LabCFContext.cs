using Microsoft.EntityFrameworkCore;
namespace PDPDay9LabCF.Models
{
    public class PDPDay9LabCFContext : DbContext
    {
        public PDPDay9LabCFContext(DbContextOptions<PDPDay9LabCFContext> options) : base(options) { }
        public DbSet<PDPLoai_San_Pham> tvcLoai_San_Phams { get; set; }
        public DbSet<PDPSan_Pham> tvcSan_Phams { get; set; }
    }
}
