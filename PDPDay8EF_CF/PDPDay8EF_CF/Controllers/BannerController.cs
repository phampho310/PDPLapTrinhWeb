using Microsoft.AspNetCore.Mvc;
using PDPDay8EF_CF.Models;
using Microsoft.EntityFrameworkCore;

namespace PDPDay8EF_CF.Controllers
{
    public class BannerController : Controller
    {
        private readonly AppDbContext _context;

        public BannerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Banner
        public IActionResult Index()
        {
            var banners = _context.Banners.ToList();
            return View(banners);
        }

        // GET: Banner/Details/5
        public IActionResult Details(int id)
        {
            var banner = _context.Banners.FirstOrDefault(b => b.Id == id);
            if (banner == null) return NotFound();
            return View(banner);
        }

        // GET: Banner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Banner banner)
        {
            if (ModelState.IsValid)
            {
                banner.CreatedDate = DateTime.Now;
                _context.Add(banner);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }

        // GET: Banner/Edit/5
        public IActionResult Edit(int id)
        {
            var banner = _context.Banners.Find(id);
            if (banner == null) return NotFound();
            return View(banner);
        }

        // POST: Banner/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Banner banner)
        {
            if (id != banner.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(banner);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }

        // GET: Banner/Delete/5
        public IActionResult Delete(int id)
        {
            var banner = _context.Banners.Find(id);
            if (banner == null) return NotFound();
            return View(banner);
        }

        // POST: Banner/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var banner = _context.Banners.Find(id);
            if (banner != null)
            {
                _context.Banners.Remove(banner);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
