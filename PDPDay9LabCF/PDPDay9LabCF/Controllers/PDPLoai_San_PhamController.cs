using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDPDay9LabCF.Models;

namespace PDPDay9LabCF.Controllers
{
    public class PDPLoai_San_PhamController : Controller
    {
        private readonly PDPDay9LabCFContext _context;

        public PDPLoai_San_PhamController(PDPDay9LabCFContext context)
        {
            _context = context;
        }

        // GET: PDPLoai_San_Pham
        public async Task<IActionResult> Index()
        {
            return View(await _context.tvcLoai_San_Phams.ToListAsync());
        }

        // GET: PDPLoai_San_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDPLoai_San_Pham = await _context.tvcLoai_San_Phams
                .FirstOrDefaultAsync(m => m.pdpId == id);
            if (pDPLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(pDPLoai_San_Pham);
        }

        // GET: PDPLoai_San_Pham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PDPLoai_San_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pdpId,pdpMaLoai,pdpTenLoai,pdpTrangThai")] PDPLoai_San_Pham pDPLoai_San_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pDPLoai_San_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pDPLoai_San_Pham);
        }

        // GET: PDPLoai_San_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDPLoai_San_Pham = await _context.tvcLoai_San_Phams.FindAsync(id);
            if (pDPLoai_San_Pham == null)
            {
                return NotFound();
            }
            return View(pDPLoai_San_Pham);
        }

        // POST: PDPLoai_San_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("pdpId,pdpMaLoai,pdpTenLoai,pdpTrangThai")] PDPLoai_San_Pham pDPLoai_San_Pham)
        {
            if (id != pDPLoai_San_Pham.pdpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pDPLoai_San_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PDPLoai_San_PhamExists(pDPLoai_San_Pham.pdpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pDPLoai_San_Pham);
        }

        // GET: PDPLoai_San_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDPLoai_San_Pham = await _context.tvcLoai_San_Phams
                .FirstOrDefaultAsync(m => m.pdpId == id);
            if (pDPLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(pDPLoai_San_Pham);
        }

        // POST: PDPLoai_San_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var pDPLoai_San_Pham = await _context.tvcLoai_San_Phams.FindAsync(id);
            if (pDPLoai_San_Pham != null)
            {
                _context.tvcLoai_San_Phams.Remove(pDPLoai_San_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PDPLoai_San_PhamExists(long id)
        {
            return _context.tvcLoai_San_Phams.Any(e => e.pdpId == id);
        }
    }
}
