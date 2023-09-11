using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PracticeAreaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
