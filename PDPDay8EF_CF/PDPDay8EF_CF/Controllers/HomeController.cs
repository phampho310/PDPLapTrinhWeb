using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDPDay8EF_CF.Models;
using System.Diagnostics;

namespace PDPDay8EF_CF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // ✅ Trang hiển thị danh sách sản phẩm (lấy từ ProductController)
        public IActionResult Product()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
