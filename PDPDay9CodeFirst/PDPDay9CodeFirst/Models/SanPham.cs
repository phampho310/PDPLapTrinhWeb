namespace PDPDay9CodeFirst.Models
{
    public class SanPham
    {
        public int ID { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public int MaLoai { get; set; }
        public bool TrangThai { get; set; }

        public LoaiSanPham LoaiSanPham { get; set; }
        public ICollection<CTHoaDon> CTHoaDons { get; set; }
    }
}
