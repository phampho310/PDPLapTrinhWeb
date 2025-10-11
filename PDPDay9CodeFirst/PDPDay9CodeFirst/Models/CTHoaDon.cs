namespace PDPDay9CodeFirst.Models
{
    public class CTHoaDon
    {
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuongMua { get; set; }
        public decimal DonGiaMua { get; set; }
        public decimal ThanhTien => SoLuongMua * DonGiaMua;
        public bool TrangThai { get; set; }

        public HoaDon HoaDon { get; set; }
        public SanPham SanPham { get; set; }
    }
}
