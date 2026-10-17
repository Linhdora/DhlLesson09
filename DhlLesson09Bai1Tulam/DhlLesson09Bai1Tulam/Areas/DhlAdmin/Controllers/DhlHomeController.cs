using Microsoft.AspNetCore.Mvc;

namespace DhlLesson09Bai1Tulam.Areas.DhlAdmin.Controllers
{
    [Area("DhlAdmin")]
    public class DhlHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
