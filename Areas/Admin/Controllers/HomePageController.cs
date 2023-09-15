using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomePageController : Controller
    {
        private readonly Context _context;

        public HomePageController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            HomePage homePage = _context.HomePages.FirstOrDefault();

            return View(homePage);
        }
        [HttpPost]
        public IActionResult Index(HomePage homePage)
        {
            if (ModelState.IsValid)
            {

                _context.Update(homePage);
                _context.SaveChanges();


            }
            else
            {
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    if (state.Errors.Count > 0)
                    {
                        foreach (var error in state.Errors)
                        {
                            var errorMessage = error.ErrorMessage;

                        }
                    }
                }
            }
            return View(homePage);           
        }
    }
}
