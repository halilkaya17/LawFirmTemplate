using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutUsController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AboutUsController(Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _context.AboutUs.FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(AboutUs aboutUs)
        {
            // Logo (Açık Zemin) yüklemesi
            var Image1 = Request.Form.Files["Image1"];
            if (Image1 != null && Image1.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "AboutUs");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image1.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Image1.CopyTo(stream);
                    }
                    aboutUs.Image1 = "/UI/AboutUs/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    // Hata yakalandığında hata mesajını görüntüle
                    Console.WriteLine(ex.Message);
                }
                aboutUs.Image1 = "/UI/AboutUs/" + uniqueFileName;
            }

            var Image2 = Request.Form.Files["Image2"];
            if (Image2 != null && Image2.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "AboutUs");

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image2.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Image2.CopyTo(stream);
                }
                aboutUs.Image2 = "/UI/AboutUs/" + uniqueFileName;
            }         

                _context.Update(aboutUs);
                _context.SaveChanges();
            
          
            return View(aboutUs);
        }
    }
}
