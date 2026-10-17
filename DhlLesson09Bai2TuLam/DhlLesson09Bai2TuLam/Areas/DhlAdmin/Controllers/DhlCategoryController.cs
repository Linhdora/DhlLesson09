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
    public class DhlCategoryController : Controller
    {
        private readonly DhlAppDbContext _context;

        public DhlCategoryController(DhlAppDbContext context)
        {
            _context = context;
        }

        // GET: DhlCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.DhlCategories.ToListAsync());
        }

        // GET: DhlCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var dhlCategory = await _context.DhlCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (dhlCategory == null) return NotFound();

            return View(dhlCategory);
        }

        // GET: DhlCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DhlCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,CreatedDate,Image,Description")] DhlCategory dhlCategory)
        {
            if (_context.DhlCategories.Any(c => c.Name == dhlCategory.Name))
                ModelState.AddModelError("Name", "Tên danh mục đã tồn tại (ràng buộc không trùng)!");

            if (ModelState.IsValid)
            {
                _context.Add(dhlCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dhlCategory);
        }

        // GET: DhlCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var dhlCategory = await _context.DhlCategories.FindAsync(id);
            if (dhlCategory == null) return NotFound();
            return View(dhlCategory);
        }

        // POST: DhlCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,CreatedDate,Image,Description")] DhlCategory dhlCategory)
        {
            if (id != dhlCategory.Id) return NotFound();

            if (_context.DhlCategories.Any(c => c.Name == dhlCategory.Name && c.Id != id))
                ModelState.AddModelError("Name", "Tên danh mục đã tồn tại (ràng buộc không trùng)!");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dhlCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DhlCategoryExists(dhlCategory.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dhlCategory);
        }

        // GET: DhlCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dhlCategory = await _context.DhlCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (dhlCategory == null) return NotFound();

            return View(dhlCategory);
        }

        // POST: DhlCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dhlCategory = await _context.DhlCategories.FindAsync(id);
            if (dhlCategory != null) _context.DhlCategories.Remove(dhlCategory);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DhlCategoryExists(int id) => _context.DhlCategories.Any(e => e.Id == id);
    }
}
