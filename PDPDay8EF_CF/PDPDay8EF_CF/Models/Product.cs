using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDPDay8EF_CF.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150, ErrorMessage = "Tên sản phẩm giới hạn 150 ký tự")]
        [Column(TypeName = "nvarchar(150)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Precision(18, 2)] // 👈 thêm precision cho Price
        public decimal Price { get; set; }

        [Precision(18, 2)] // 👈 thêm precision cho SalePrice
        public decimal SalePrice { get; set; }

        public byte Status { get; set; }

        [StringLength(1000, ErrorMessage = "Nội dung mô tả giới hạn 1000 ký tự")]
        [Column(TypeName = "ntext")]
        public string? Descriptions { get; set; }

        [Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }

        // Khóa ngoại tới bảng Category
        public Category? Category { get; set; }
    }
}
