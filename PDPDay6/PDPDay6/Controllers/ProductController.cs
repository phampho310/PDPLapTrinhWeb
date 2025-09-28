using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDPDay6.Models;

namespace PDPDay6.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null) return NotFound();

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model, IFormFile? file)
        {
            if (model.SalePrice >= model.Price * 0.9f)
            {
                ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn 90% giá gốc");
            }

            if (!ModelState.IsValid)
            {
                LoadCategories(model.CategoryId);
                return View(model);
            }

            // Upload ảnh nếu có
            if (file != null && file.Length > 0)
            {
                model.Image = await SaveFile(file);
            }

            _context.Products.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            LoadCategories(product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product model, IFormFile? file)
        {
            if (id != model.Id) return NotFound();

            if (model.SalePrice >= model.Price * 0.9f)
            {
                ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn 90% giá gốc");
            }

            if (!ModelState.IsValid)
            {
                LoadCategories(model.CategoryId);
                return View(model);
            }

            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound();

                // Cập nhật dữ liệu
                product.Name = model.Name;
                product.Price = model.Price;
                product.SalePrice = model.SalePrice;
                product.Description = model.Description;
                product.CategoryId = model.CategoryId;

                // Upload ảnh mới nếu có
                if (file != null && file.Length > 0)
                {
                    product.Image = await SaveFile(file);
                }

                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.Id == model.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null) return NotFound();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // ---------------- Helper ----------------
        private void LoadCategories(int? selectedId = null)
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", selectedId);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products");
            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadDir, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "/products/" + fileName;
        }
    }
}
