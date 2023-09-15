using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TeamsController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeamsController(Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var values = _context.OurTeams.ToList();
            return View(values);
        }

        public IActionResult Edit(int id)
        {
            var allTeamMembers = _context.OurTeams.ToList();

            var ourTeam = allTeamMembers.FirstOrDefault(x => x.Id == id);

            if (ourTeam == null)
            {
                return NotFound(); // Belirtilen Id ile bir ekip üyesi bulunamadıysa hata döndürün.
            }

            return View(ourTeam);
        }

        [HttpPost]
        public IActionResult Edit(OurTeam ourTeam)
        {
            // Logo (Açık Zemin) yüklemesi
            var Image = Request.Form.Files["Image"];
            if (Image != null && Image.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "Team");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }
                    ourTeam.Image = "/UI/Team/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    // Hata yakalandığında hata mesajını görüntüle
                    Console.WriteLine(ex.Message);
                }
                ourTeam.Image = "/UI/Team/" + uniqueFileName;
            }

            _context.Update(ourTeam);
            _context.SaveChanges();

            return View(ourTeam);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(OurTeam ourTeams)
        {
            // Logo (Açık Zemin) yüklemesi
            var Image = Request.Form.Files["Image"];
            if (Image != null && Image.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "OurTeam");

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }
                    ourTeams.Image = "/UI/OurTeam/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    // Hata yakalandığında hata mesajını görüntüle
                    Console.WriteLine(ex.Message);
                }
            }

            _context.OurTeams.Add(ourTeams);
            _context.SaveChanges();


            return RedirectToAction("Index", "Teams", new { area = "Admin" });
            
        }


    }
}
