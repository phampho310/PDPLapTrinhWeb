namespace PDPTH1.Models
{
    public class Student
    {
        public int Id { get; set; } // Mã sinh viên
        public string? Name { get; set; } // Tên sinh viên
        public string? Email { get; set; } // Email
        public string? PassWord { get; set; } // Mật khẩu
        public Branch? Branch { get; set; } // Ngành học
        public Gender? Gender { get; set; } // Giới tính
        public bool IsRegular { get; set; } // Hệ chính quy
        public string? Address { get; set; } // Địa chỉ
        public DateTime DateOfBorth { get; set; } // Ngày sinh
        public string? Avatar { get; set; } // Ảnh đại diện

    }
}
