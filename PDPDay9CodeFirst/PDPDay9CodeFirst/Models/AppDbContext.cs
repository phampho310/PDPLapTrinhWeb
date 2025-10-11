using Microsoft.EntityFrameworkCore;

namespace PDPDay9CodeFirst.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<CTHoaDon> CTHoaDon { get; set; }
        public DbSet<QuanTri> QuanTri { get; set; }
    }
}
