namespace PDPDay9CodeFirst.Models
{
    public class LoaiSanPham
    {
        public int ID { get; set; }
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public bool TrangThai { get; set; }

        public ICollection<SanPham> SanPhams { get; set; }
    }
}
