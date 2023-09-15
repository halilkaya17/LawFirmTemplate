using LawFirmTemplate.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {

            return View();
        }
    }
}
