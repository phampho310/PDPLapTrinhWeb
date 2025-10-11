using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PDPDay9DatabaseFirst.Models;

public partial class QlbanHangContext : DbContext
{
    public QlbanHangContext()
    {
    }

    public QlbanHangContext(DbContextOptions<QlbanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CthoaDon> CthoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<QuanTri> QuanTris { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PHAMDANHPHO\\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CthoaDon>(entity =>
        {
            entity.ToTable("CTHoaDon");

            entity.HasIndex(e => e.HoaDonId, "IX_CTHoaDon_HoaDonID");

            entity.HasIndex(e => e.SanPhamId, "IX_CTHoaDon_SanPhamID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGiaMua).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HoaDonId).HasColumnName("HoaDonID");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");

            entity.HasOne(d => d.HoaDon).WithMany(p => p.CthoaDons).HasForeignKey(d => d.HoaDonId);

            entity.HasOne(d => d.SanPham).WithMany(p => p.CthoaDons).HasForeignKey(d => d.SanPhamId);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.ToTable("HoaDon");

            entity.HasIndex(e => e.KhachHangId, "IX_HoaDon_KhachHangID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KhachHangId).HasColumnName("KhachHangID");
            entity.Property(e => e.TongTriGia).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.KhachHang).WithMany(p => p.HoaDons).HasForeignKey(d => d.KhachHangId);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.ToTable("KhachHang");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.ToTable("LoaiSanPham");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<QuanTri>(entity =>
        {
            entity.ToTable("QuanTri");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.ToTable("SanPham");

            entity.HasIndex(e => e.LoaiSanPhamId, "IX_SanPham_LoaiSanPhamID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LoaiSanPhamId).HasColumnName("LoaiSanPhamID");

            entity.HasOne(d => d.LoaiSanPham).WithMany(p => p.SanPhams).HasForeignKey(d => d.LoaiSanPhamId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
