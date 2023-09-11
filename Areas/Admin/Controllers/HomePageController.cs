using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    public class HomePageController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
