using System.ComponentModel.DataAnnotations;

namespace PDPDay5Lab_Model.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public bool Status { get; set; }    
    }
}
