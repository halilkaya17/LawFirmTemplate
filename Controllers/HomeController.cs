using LawFirmTemplate.Data;
using LawFirmTemplate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.HomePage= _context.HomePages.FirstOrDefault();

            homeViewModel.Articles= _context.Articles.ToList();

            homeViewModel.OurTeams= _context.OurTeams.ToList();

            homeViewModel.PracticeAreas= _context.PracticeAreas.ToList();

            homeViewModel.Slider = _context.Sliders.FirstOrDefault();

            return View(homeViewModel);
        }
    }
}
