using LawFirmTemplate.Data;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class _NavbarController : Controller
    { 
        private readonly Context _context;

        public _NavbarController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.GeneralSettings.FirstOrDefault();
            return View(values);
        }
    }
}
