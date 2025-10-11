namespace PDPDay9CodeFirst.Models
{
    public class KhachHang
    {
        public int ID { get; set; }
        public string MaKhachHang { get; set; }
        public string HoTenKhachHang { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayDangKy { get; set; }
        public bool TrangThai { get; set; }

        public ICollection<HoaDon> HoaDons { get; set; }
    }
}
