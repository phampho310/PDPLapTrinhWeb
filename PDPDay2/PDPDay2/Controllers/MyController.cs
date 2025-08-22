using Microsoft.AspNetCore.Mvc;

namespace PDPDay2.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sample()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
    }
}
