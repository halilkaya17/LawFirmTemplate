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
            var Article = _context.Articles.FirstOrDefault(x => x.Id == id);

            if (Article == null)
            {
                return View("Index"); // Belirtilen Id ile bir ekip üyesi bulunamadıysa hata döndürün.
            }

            return View(Article);

        }
	}
}
