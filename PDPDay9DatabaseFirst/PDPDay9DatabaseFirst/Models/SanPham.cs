using System;
using System.Collections.Generic;

namespace PDPDay9DatabaseFirst.Models;

public partial class SanPham
{
    public int Id { get; set; }

    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public string HinhAnh { get; set; } = null!;

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public int MaLoai { get; set; }

    public bool TrangThai { get; set; }

    public int LoaiSanPhamId { get; set; }

    public virtual ICollection<CthoaDon> CthoaDons { get; set; } = new List<CthoaDon>();

    public virtual LoaiSanPham LoaiSanPham { get; set; } = null!;
}
