using Microsoft.AspNetCore.Mvc;

namespace DhlLesson09Bai2TuLam.Controllers
{
    public class DhlHomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "DhlHome", new { area = "DhlAdmin" });
        }
    }
}
