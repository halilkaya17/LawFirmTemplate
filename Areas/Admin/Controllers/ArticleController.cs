using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
