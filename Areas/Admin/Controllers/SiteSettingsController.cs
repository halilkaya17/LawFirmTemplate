using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SiteSettingsController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SiteSettingsController(Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult GeneralSettings()
        {
            GeneralSetting generalSetting = _context.GeneralSettings.FirstOrDefault();

            return View(generalSetting);
        }
        [HttpPost]
        public async Task<IActionResult> GeneralSettings(GeneralSetting generalSetting)
        {
            // Logo (Açık Zemin) yüklemesi
            var Light = Request.Form.Files["Light"];
            if (Light != null && Light.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "Team");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Light.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Light.CopyTo(stream);
                    }
                    generalSetting.LogoLight = "/UI/Team/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    // Hata yakalandığında hata mesajını görüntüle
                    Console.WriteLine(ex.Message);
                }
                generalSetting.LogoLight = "/UI/Team/" + uniqueFileName;
            }

            var Dark = Request.Form.Files["Dark"];
            if (Dark != null && Dark.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "Team");

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Dark.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Dark.CopyTo(stream);
                }
                generalSetting.LogoDark = "/UI/Team/" + uniqueFileName;
            }

            var Fav = Request.Form.Files["Fav"];
            if (Fav != null && Fav.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "Team");

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Fav.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Fav.CopyTo(stream);
                }
                generalSetting.Favicon = "/UI/Team/" + uniqueFileName;
            }           
                _context.Update(generalSetting);
                _context.SaveChanges();    


            return View(generalSetting);
        }


        [HttpGet]
        public IActionResult ContactSettings()
        {

            ContactUs contactUs = _context.ContactUs.FirstOrDefault();


            return View(contactUs);
        }
        [HttpPost]
        public IActionResult ContactSettings(ContactUs model)
        {
                       
            if (ModelState.IsValid)
            {

                _context.Update(model);
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
            return View(model);
        }
        
    }
}
