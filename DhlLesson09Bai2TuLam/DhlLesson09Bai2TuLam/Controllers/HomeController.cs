using Microsoft.AspNetCore.Mvc;

namespace DhlLesson09Bai2TuLam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "DhlHome");
        }

        public IActionResult Privacy()
        {
            return RedirectToAction("Privacy", "DhlHome");
        }
    }
}
