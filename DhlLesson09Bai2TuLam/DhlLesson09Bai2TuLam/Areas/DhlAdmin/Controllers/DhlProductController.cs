using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DhlLesson09Bai2TuLam.Areas.DhlAdmin.Models;

namespace DhlLesson09Bai2TuLam.Areas.DhlAdmin.Controllers
{
    [Area("DhlAdmin")]
    public class DhlProductController : Controller
    {
        private readonly DhlAppDbContext _context;

        public DhlProductController(DhlAppDbContext context)
        {
            _context = context;
        }

        // GET: DhlProduct
        public async Task<IActionResult> Index()
        {
            var dhlAppDbContext = _context.DhlProducts.Include(d => d.Category);
            return View(await dhlAppDbContext.ToListAsync());
        }

        // GET: DhlProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var dhlProduct = await _context.DhlProducts.Include(d => d.Category).FirstOrDefaultAsync(m => m.Id == id);
            if (dhlProduct == null) return NotFound();

            return View(dhlProduct);
        }

        // GET: DhlProduct/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.DhlCategories, "Id", "Name");
            return View();
        }

        // POST: DhlProduct/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,salePrice,Status,CategoryId,CreatedDate,Image,Description")] DhlProduct dhlProduct)
        {
            if (_context.DhlProducts.Any(p => p.Name == dhlProduct.Name))
                ModelState.AddModelError("Name", "Tên sản phẩm đã tồn tại (ràng buộc không trùng)!");

            if (ModelState.IsValid)
            {
                _context.Add(dhlProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.DhlCategories, "Id", "Name", dhlProduct.CategoryId);
            return View(dhlProduct);
        }

        // GET: DhlProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var dhlProduct = await _context.DhlProducts.FindAsync(id);
            if (dhlProduct == null) return NotFound();
            ViewData["CategoryId"] = new SelectList(_context.DhlCategories, "Id", "Name", dhlProduct.CategoryId);
            return View(dhlProduct);
        }

        // POST: DhlProduct/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,salePrice,Status,CategoryId,CreatedDate,Image,Description")] DhlProduct dhlProduct)
        {
            if (id != dhlProduct.Id) return NotFound();

            if (_context.DhlProducts.Any(p => p.Name == dhlProduct.Name && p.Id != id))
                ModelState.AddModelError("Name", "Tên sản phẩm đã tồn tại (ràng buộc không trùng)!");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dhlProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DhlProductExists(dhlProduct.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.DhlCategories, "Id", "Name", dhlProduct.CategoryId);
            return View(dhlProduct);
        }

        // GET: DhlProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dhlProduct = await _context.DhlProducts.Include(d => d.Category).FirstOrDefaultAsync(m => m.Id == id);
            if (dhlProduct == null) return NotFound();

            return View(dhlProduct);
        }

        // POST: DhlProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dhlProduct = await _context.DhlProducts.FindAsync(id);
            if (dhlProduct != null) _context.DhlProducts.Remove(dhlProduct);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DhlProductExists(int id) => _context.DhlProducts.Any(e => e.Id == id);
    }
}
