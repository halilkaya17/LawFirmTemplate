using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class PracticeAreasController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PracticeAreasController(Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(PracticeAreas practiceAreas)
        {
            var values = _context.PracticeAreas.ToList();

            return View(values);
        }
        public IActionResult Detail(int id)
        {
            var allPracticeAreas = _context.PracticeAreas.ToList();

            var practiceArea = allPracticeAreas.FirstOrDefault(x => x.Id == id);

            if (practiceArea == null)
            {
                return NotFound(); // Belirtilen Id ile bir ekip üyesi bulunamadıysa hata döndürün.
            }

            return View(practiceArea);
        }
    }
}
