using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class CareerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
