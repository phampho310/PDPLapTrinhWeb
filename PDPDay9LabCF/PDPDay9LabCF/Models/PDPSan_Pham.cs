using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PDPDay9LabCF.Models
{
    [Table("PDPSan_Pham")]
    public class PDPSan_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long pdpId { get; set; }

        [Display(Name = "Mã sản phẩm")]
        [Required]
        [StringLength(10)]
        public string pdpMaSanPham { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string pdpTenSanPham { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? pdpHinhAnh { get; set; }

        [Display(Name = "Số lượng")]
        public int pdpSoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal pdpDonGia { get; set; }


        public long pdpLoaiSanPhamId { get; set; }

        public PDPLoai_San_Pham pdpLoai_San_Pham { get; set; }
    }
}
