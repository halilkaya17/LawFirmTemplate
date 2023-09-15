using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PracticeAreaController : Controller
    {
		private readonly Context _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public PracticeAreaController(Context context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
		}

		[HttpGet]
        public IActionResult Index()
        {
            var values= _context.PracticeAreas.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var allPracticeAreas = _context.PracticeAreas.ToList();

            var practiceArea = allPracticeAreas.FirstOrDefault(x => x.Id == id);

            if (practiceArea == null)
            {
                return NotFound(); // Belirtilen Id ile bir ekip üyesi bulunamadıysa hata döndürün.
            }

            return View(practiceArea);
        }

        [HttpPost]
        public IActionResult Detail(PracticeAreas practiceAreas)
        {
            // Logo (Açık Zemin) yüklemesi
            var Symbol = Request.Form.Files["Symbol"];
            if (Symbol != null && Symbol.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "Symbol");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Symbol.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Symbol.CopyTo(stream);
                    }
                    practiceAreas.Icon = "/UI/Symbol/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    // Hata yakalandığında hata mesajını görüntüle
                    Console.WriteLine(ex.Message);
                }
            }
            // Logo (Açık Zemin) yüklemesi
            var Image = Request.Form.Files["Image"];
            if (Image != null && Image.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "PracticeAreas");

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
                    practiceAreas.Image = "/UI/PracticeAreas/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    // Hata yakalandığında hata mesajını görüntüle
                    Console.WriteLine(ex.Message);
                }
                practiceAreas.Image = "/UI/PracticeAreas/" + uniqueFileName;
            }

            _context.Update(practiceAreas);
            _context.SaveChanges();

            return View(practiceAreas);
        }

        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Create(PracticeAreas practiceAreas)
        {
			// Logo (Açık Zemin) yüklemesi
			var Symbol = Request.Form.Files["Symbol"];
			if (Symbol != null && Symbol.Length > 0)
			{
				// Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "Symbol");

				if (!Directory.Exists(uploadsFolder))
				{
					Directory.CreateDirectory(uploadsFolder);
				}

				// Dosya adını ve yolunu oluşturun
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + Symbol.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				// Logo (Açık Zemin) dosyasını kaydedin
				try
				{
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						Symbol.CopyTo(stream);
					}
					practiceAreas.Icon = "/UI/Symbol/" + uniqueFileName;
				}
				catch (Exception ex)
				{
					// Hata yakalandığında hata mesajını görüntüle
					Console.WriteLine(ex.Message);
				}
			}

			// Logo (Açık Zemin) yüklemesi
			var Image = Request.Form.Files["Image"];
			if (Image != null && Image.Length > 0)
			{
				// Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "PracticeAreas");

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
					practiceAreas.Image = "/UI/PracticeAreas/" + uniqueFileName;
				}
				catch (Exception ex)
				{
					// Hata yakalandığında hata mesajını görüntüle
					Console.WriteLine(ex.Message);
				}
			}

			_context.PracticeAreas.Add(practiceAreas);
			_context.SaveChanges();


			return RedirectToAction("Index", "PracticeArea", new { area = "Admin" });
			
        }
    }
}
