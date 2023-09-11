using LawFirmTemplate.Data;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class OurTeamController : Controller
    {
        private readonly Context _context;

        public OurTeamController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.OurTeams.ToList();

            return View(values);
        }
    }
}
