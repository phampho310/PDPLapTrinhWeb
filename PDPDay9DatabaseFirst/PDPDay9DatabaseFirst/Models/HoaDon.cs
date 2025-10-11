using System;
using System.Collections.Generic;

namespace PDPDay9DatabaseFirst.Models;

public partial class HoaDon
{
    public int Id { get; set; }

    public string MaHoaDon { get; set; } = null!;

    public int? MaKhachHang { get; set; }

    public DateTime NgayHoaDon { get; set; }

    public DateTime? NgayNhan { get; set; }

    public string HoTenKhachHang { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DienThoai { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public decimal TongTriGia { get; set; }

    public bool TrangThai { get; set; }

    public int KhachHangId { get; set; }

    public virtual ICollection<CthoaDon> CthoaDons { get; set; } = new List<CthoaDon>();

    public virtual KhachHang KhachHang { get; set; } = null!;
}
