using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly Context _context;

        public MessageController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.ContactUs.ToList();
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(ContactUs contactUs)
        {
            _context.ContactUs.Add(contactUs);
            _context.SaveChanges();


            return View();
        }
    }
}
