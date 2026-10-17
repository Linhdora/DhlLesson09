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
    public class DhlBannerController : Controller
    {
        private readonly DhlAppDbContext _context;

        public DhlBannerController(DhlAppDbContext context)
        {
            _context = context;
        }

        // GET: DhlBanner
        public async Task<IActionResult> Index()
        {
            return View(await _context.DhlBanners.ToListAsync());
        }

        // GET: DhlBanner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var dhlBanner = await _context.DhlBanners.FirstOrDefaultAsync(m => m.Id == id);
            if (dhlBanner == null) return NotFound();

            return View(dhlBanner);
        }

        // GET: DhlBanner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DhlBanner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,Prioty,Image,Description")] DhlBanner dhlBanner)
        {
            if (_context.DhlBanners.Any(b => b.Name == dhlBanner.Name))
                ModelState.AddModelError("Name", "Tên banner đã tồn tại (ràng buộc không trùng)!");

            if (ModelState.IsValid)
            {
                _context.Add(dhlBanner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dhlBanner);
        }

        // GET: DhlBanner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var dhlBanner = await _context.DhlBanners.FindAsync(id);
            if (dhlBanner == null) return NotFound();
            return View(dhlBanner);
        }

        // POST: DhlBanner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,Prioty,Image,Description")] DhlBanner dhlBanner)
        {
            if (id != dhlBanner.Id) return NotFound();

            if (_context.DhlBanners.Any(b => b.Name == dhlBanner.Name && b.Id != id))
                ModelState.AddModelError("Name", "Tên banner đã tồn tại (ràng buộc không trùng)!");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dhlBanner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DhlBannerExists(dhlBanner.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dhlBanner);
        }

        // GET: DhlBanner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dhlBanner = await _context.DhlBanners.FirstOrDefaultAsync(m => m.Id == id);
            if (dhlBanner == null) return NotFound();

            return View(dhlBanner);
        }

        // POST: DhlBanner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dhlBanner = await _context.DhlBanners.FindAsync(id);
            if (dhlBanner != null) _context.DhlBanners.Remove(dhlBanner);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DhlBannerExists(int id) => _context.DhlBanners.Any(e => e.Id == id);
    }
}
