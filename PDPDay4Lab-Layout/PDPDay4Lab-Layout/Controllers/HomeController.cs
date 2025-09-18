using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Dashboard";
        ViewData["PageTitle"] = "Tổng quan";
        return View();
    }

    public IActionResult Tables()
    {
        ViewData["Title"] = "Tables";
        ViewData["PageTitle"] = "Bảng dữ liệu";
        return View("Index");
    }

    public IActionResult Forms()
    {
        ViewData["Title"] = "Forms";
        ViewData["PageTitle"] = "Biểu mẫu";
        return View("Index");
    }
}
