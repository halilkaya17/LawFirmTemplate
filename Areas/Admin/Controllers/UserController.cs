using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
