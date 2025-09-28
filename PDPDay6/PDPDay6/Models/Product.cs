using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDPDay6.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [MinLength(6, ErrorMessage = "Tên sản phẩm ít nhất 6 ký tự")]
        [MaxLength(150, ErrorMessage = "Tên sản phẩm tối đa 150 ký tự")]
        public string Name { get; set; }

        // ❌ bỏ Required vì ảnh sẽ được gán khi upload
        public string? Image { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Giá khuyến mãi không được để trống")]
        [Range(0, 100000, ErrorMessage = "Giá khuyến mãi phải nhỏ hơn giá chuẩn 10%")]
        public float SalePrice { get; set; }

        [Required(ErrorMessage = "Danh mục không được để trống")]
        public int? CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [MaxLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")]
        [RegularExpression(@"(?s)^(?!.*\b(die|fuck|shit)\b).*$", ErrorMessage = "Mô tả chứa từ nhạy cảm")]
        public string? Description { get; set; }

    }
}
