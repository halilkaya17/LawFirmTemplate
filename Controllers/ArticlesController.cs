using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly Context _context;

        public ArticlesController(Context context)
        {
            _context = context;
        }

        public IActionResult Index(Article article)
        {
            var values = _context.Articles.ToList();
            return View(values);
        }

        
		public IActionResult Detail(int id)
		{
            var allArticles = _context.PracticeAreas.ToList();

            var Article = allArticles.FirstOrDefault(x => x.Id == id);

            if (Article == null)
            {
                return NotFound(); // Belirtilen Id ile bir ekip üyesi bulunamadıysa hata döndürün.
            }

            return View(Article);

        }
	}
}
