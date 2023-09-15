using LawFirmTemplate.Data;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly Context _context;

        public AboutUsController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.AboutUs.FirstOrDefault();
            return View(values);
        }
    }
}
