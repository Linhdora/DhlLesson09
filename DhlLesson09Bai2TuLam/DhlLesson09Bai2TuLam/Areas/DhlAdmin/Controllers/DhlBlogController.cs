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
    public class DhlBlogController : Controller
    {
        private readonly DhlAppDbContext _context;

        public DhlBlogController(DhlAppDbContext context)
        {
            _context = context;
        }

        // GET: DhlBlog
        public async Task<IActionResult> Index()
        {
            return View(await _context.DhlBlogs.ToListAsync());
        }

        // GET: DhlBlog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var dhlBlog = await _context.DhlBlogs.FirstOrDefaultAsync(m => m.Id == id);
            if (dhlBlog == null) return NotFound();

            return View(dhlBlog);
        }

        // GET: DhlBlog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DhlBlog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,CreatedDate,Image,Description")] DhlBlog dhlBlog)
        {
            if (_context.DhlBlogs.Any(b => b.Name == dhlBlog.Name))
                ModelState.AddModelError("Name", "Tên bài viết đã tồn tại (ràng buộc không trùng)!");

            if (ModelState.IsValid)
            {
                _context.Add(dhlBlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dhlBlog);
        }

        // GET: DhlBlog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var dhlBlog = await _context.DhlBlogs.FindAsync(id);
            if (dhlBlog == null) return NotFound();
            return View(dhlBlog);
        }

        // POST: DhlBlog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,CreatedDate,Image,Description")] DhlBlog dhlBlog)
        {
            if (id != dhlBlog.Id) return NotFound();

            if (_context.DhlBlogs.Any(b => b.Name == dhlBlog.Name && b.Id != id))
                ModelState.AddModelError("Name", "Tên bài viết đã tồn tại (ràng buộc không trùng)!");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dhlBlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DhlBlogExists(dhlBlog.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dhlBlog);
        }

        // GET: DhlBlog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dhlBlog = await _context.DhlBlogs.FirstOrDefaultAsync(m => m.Id == id);
            if (dhlBlog == null) return NotFound();

            return View(dhlBlog);
        }

        // POST: DhlBlog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dhlBlog = await _context.DhlBlogs.FindAsync(id);
            if (dhlBlog != null) _context.DhlBlogs.Remove(dhlBlog);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DhlBlogExists(int id) => _context.DhlBlogs.Any(e => e.Id == id);
    }
}
