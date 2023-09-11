using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
