using Microsoft.AspNetCore.Mvc;

namespace DhlLesson09.Areas.DhlAdmins.Controllers
{
    [Area("DhlAdmins")]
    public class DhlDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
