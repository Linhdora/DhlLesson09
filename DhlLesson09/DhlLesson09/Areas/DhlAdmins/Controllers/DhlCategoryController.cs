using Microsoft.AspNetCore.Mvc;

namespace DhlLesson09.Areas.DhlAdmins.Controllers
{
    [Area("DhlAdmins")]
    public class DhlCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
