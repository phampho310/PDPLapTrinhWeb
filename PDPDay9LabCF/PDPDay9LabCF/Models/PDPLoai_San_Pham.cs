using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PDPDay9LabCF.Models
{
    [Table("PDPLoai_San_Pham")]
    [Index(nameof(pdpMaLoai), IsUnique = true)]
    public class PDPLoai_San_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long pdpId { get; set; }

        [Display(Name = "Mã loại")]
        [StringLength(10)]
        public string pdpMaLoai { get; set; }

        [Display(Name = "Tên loại")]
        [StringLength(50)]
        public string pdpTenLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public bool pdpTrangThai { get; set; }

        public ICollection<PDPSan_Pham> pdpSan_Phams { get; set; } = new HashSet<PDPSan_Pham>();
    }
}
