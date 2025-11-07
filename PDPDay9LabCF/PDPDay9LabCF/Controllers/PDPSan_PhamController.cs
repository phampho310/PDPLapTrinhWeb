using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDPDay9LabCF.Models;

namespace PDPDay9LabCF.Controllers
{
    public class PDPSan_PhamController : Controller
    {
        private readonly PDPDay9LabCFContext _context;
        private readonly IWebHostEnvironment _environment;

        public PDPSan_PhamController(PDPDay9LabCFContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: PDPSan_Pham
        public async Task<IActionResult> Index()
        {
            return View(await _context.tvcSan_Phams.ToListAsync());
        }

        // GET: PDPSan_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return NotFound();

            var pDPSan_Pham = await _context.tvcSan_Phams.FirstOrDefaultAsync(m => m.pdpId == id);
            if (pDPSan_Pham == null)
                return NotFound();

            return View(pDPSan_Pham);
        }

        // GET: PDPSan_Pham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PDPSan_Pham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PDPSan_Pham pDPSan_Pham, IFormFile? pdpHinhAnh)
        {
            if (ModelState.IsValid)
            {
                if (pdpHinhAnh != null && pdpHinhAnh.Length > 0)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    Directory.CreateDirectory(uploadsFolder);
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(pdpHinhAnh.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await pdpHinhAnh.CopyToAsync(stream);
                    }
                    pDPSan_Pham.pdpHinhAnh = uniqueFileName;
                }

                _context.Add(pDPSan_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(pDPSan_Pham);
        }


        // GET: PDPSan_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();

            var pDPSan_Pham = await _context.tvcSan_Phams.FindAsync(id);
            if (pDPSan_Pham == null)
                return NotFound();

            return View(pDPSan_Pham);
        }

        // POST: PDPSan_Pham/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("pdpId,pdpMaSanPham,pdpTenSanPham,pdpHinhAnh,pdpSoLuong,pdpDonGia,pdpLoaiSanPhamId")] PDPSan_Pham pDPSan_Pham, IFormFile? pdpHinhAnhFile)
        {
            if (id != pDPSan_Pham.pdpId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existing = await _context.tvcSan_Phams.AsNoTracking().FirstOrDefaultAsync(p => p.pdpId == id);
                    if (existing == null)
                        return NotFound();

                    // Nếu người dùng chọn ảnh mới
                    if (pdpHinhAnhFile != null && pdpHinhAnhFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                        if (!Directory.Exists(uploadsFolder))
                            Directory.CreateDirectory(uploadsFolder);

                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(pdpHinhAnhFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await pdpHinhAnhFile.CopyToAsync(fileStream);
                        }

                        // Xóa ảnh cũ nếu có
                        if (!string.IsNullOrEmpty(existing.pdpHinhAnh))
                        {
                            string oldPath = Path.Combine(uploadsFolder, existing.pdpHinhAnh);
                            if (System.IO.File.Exists(oldPath))
                                System.IO.File.Delete(oldPath);
                        }

                        pDPSan_Pham.pdpHinhAnh = uniqueFileName;
                    }
                    else
                    {
                        // Giữ lại ảnh cũ nếu không upload mới
                        pDPSan_Pham.pdpHinhAnh = existing.pdpHinhAnh;
                    }

                    _context.Update(pDPSan_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PDPSan_PhamExists(pDPSan_Pham.pdpId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pDPSan_Pham);
        }

        // GET: PDPSan_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
                return NotFound();

            var pDPSan_Pham = await _context.tvcSan_Phams.FirstOrDefaultAsync(m => m.pdpId == id);
            if (pDPSan_Pham == null)
                return NotFound();

            return View(pDPSan_Pham);
        }

        // POST: PDPSan_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var pDPSan_Pham = await _context.tvcSan_Phams.FindAsync(id);
            if (pDPSan_Pham != null)
            {
                // Xóa ảnh khi xóa sản phẩm
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                if (!string.IsNullOrEmpty(pDPSan_Pham.pdpHinhAnh))
                {
                    string imgPath = Path.Combine(uploadsFolder, pDPSan_Pham.pdpHinhAnh);
                    if (System.IO.File.Exists(imgPath))
                        System.IO.File.Delete(imgPath);
                }

                _context.tvcSan_Phams.Remove(pDPSan_Pham);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PDPSan_PhamExists(long id)
        {
            return _context.tvcSan_Phams.Any(e => e.pdpId == id);
        }
    }
}
