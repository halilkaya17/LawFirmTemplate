using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult Detail()
		{
			return View();
		}
	}
}
