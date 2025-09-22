using Microsoft.AspNetCore.Mvc;
using PDPDay5Lab_Model.Models;
namespace PDPDay5Lab_Model.Controllers
{
    public class EmployeesController : Controller
    {
        
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FullName = "Nguyen Van A", Gender = "Nam", Phone = "0123456789", Email = "a@gmail.com", Salary = 1000, Status = true },
            new Employee { Id = 2, FullName = "Tran Thi B", Gender = "Nữ", Phone = "0987654321", Email = "b@gmail.com", Salary = 1500, Status = false },
            new Employee { Id = 3, FullName = "Le Van C", Gender = "Nam", Phone = "0909123456", Email = "c@gmail.com", Salary = 2000, Status = true },
            new Employee { Id = 4, FullName = "Le Van D", Gender = "Nam", Phone = "0909654321", Email = "d@gmail.com", Salary = 2000, Status = true }

        };

        
        public IActionResult Index()
        {
            return View(employees);
        }

        
        public IActionResult Details(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }
    }
}
