using System.Diagnostics;
using DhlLesson09Bai2TuLam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DhlLesson09Bai2TuLam.Controllers
{
    public class DhlHomeController : Controller
    {
        private readonly ILogger<DhlHomeController> _logger;
        private readonly DhlAppDbContext _context;

        public DhlHomeController(ILogger<DhlHomeController> logger, DhlAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CategoryCount = await _context.DhlCategories.CountAsync();
            ViewBag.ProductCount = await _context.DhlProducts.CountAsync();
            ViewBag.BannerCount = await _context.DhlBanners.CountAsync();
            ViewBag.BlogCount = await _context.DhlBlogs.CountAsync();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
