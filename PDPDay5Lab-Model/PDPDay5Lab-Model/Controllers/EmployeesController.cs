using Microsoft.AspNetCore.Mvc;
using PDPDay5Lab_Model.Models;
using System;
namespace PDPDay5Lab_Model.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        [HttpPost]
        public IActionResult Index(PDPDay5Lab_Model.Models.Employee emp)
        {
            var employees = _context.Employees.ToList();
            if (ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }
    }
}
