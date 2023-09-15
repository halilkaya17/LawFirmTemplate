using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SliderController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var values = _context.Sliders.FirstOrDefault();

            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Slider slider)
        {
            var Image = Request.Form.Files["Image"];
            if (Image != null && Image.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Slider)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "Slider");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }
                slider.Image = "/UI/Slider/" + uniqueFileName;
            }

            _context.Update(slider);
            _context.SaveChanges();

            return View(slider);
        }
    }
}
