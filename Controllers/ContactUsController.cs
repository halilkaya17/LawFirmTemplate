using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly Context _context;

        public ContactUsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ContactUs contactUs = _context.ContactUs.FirstOrDefault(); 
            return View(contactUs);
            
        }
    }
}
