namespace PDPDay12Lab.Models
{
    public class Student
    {
        public int Id { get; set; } // Mã sinh viên
    
        [Display(Name = "Tên sinh viên")]
        [Required(ErrorMessage = "Tên sinh viên bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên sinh viên phải từ 4 đến 100 ký tự")]
        public string? Name { get; set; }
    
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", 
            ErrorMessage = "Email phải có định dạng hợp lệ và phải có đuôi gmail.com")]
        public string? Email { get; set; }
    
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
        public string? PassWord { get; set; }
    
        [Display(Name = "Ngành học")]
        [Required(ErrorMessage = "Vui lòng chọn ngành học")]
        public Branch? Branch { get; set; }
    
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public Gender? Gender { get; set; }
    
        [Display(Name = "Hệ chính quy")]
        public bool IsRegular { get; set; }
    
        [Display(Name = "Địa chỉ")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải nhập")]
        public string? Address { get; set; }
    
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập")]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005", 
            ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        public DateTime DateOfBorth { get; set; }
    
        [Display(Name = "Ảnh đại diện")]
        public string? Avatar { get; set; }
    
        // ======== Trường Score thêm mới ========
        [Display(Name = "Điểm số")]
        [Required(ErrorMessage = "Điểm số bắt buộc phải nhập")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0")]
        public double? Score { get; set; }
    }
}
