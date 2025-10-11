namespace PDPDay9CodeFirst.Models
{
    public class HoaDon
    {
        public int ID { get; set; }
        public string MaHoaDon { get; set; }
        public int? MaKhachHang { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public DateTime? NgayNhan { get; set; }
        public string HoTenKhachHang { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public decimal TongTriGia { get; set; }
        public bool TrangThai { get; set; }

        public KhachHang KhachHang { get; set; }
        public ICollection<CTHoaDon> CTHoaDons { get; set; }
    }
}
