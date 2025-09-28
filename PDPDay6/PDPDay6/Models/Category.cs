using System.ComponentModel.DataAnnotations;

namespace PDPDay6.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [MinLength(3, ErrorMessage = "Tên danh mục phải có ít nhất 3 ký tự")]
        [MaxLength(150, ErrorMessage = "Tên danh mục không được vượt quá 150 ký tự")]
        public string Name { get; set; }
    }
}
