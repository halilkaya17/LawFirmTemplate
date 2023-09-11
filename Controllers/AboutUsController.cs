using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
