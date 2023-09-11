using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
