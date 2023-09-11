using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    public class SiteSettingsController : Controller
    {
        [Area("Admin")]
        public IActionResult GeneralSettings()
        {
            return View();
        }
        public IActionResult ContactSettings()
        {
            return View();
        }
    }
}
