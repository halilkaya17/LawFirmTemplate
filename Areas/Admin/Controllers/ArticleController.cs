using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly Context _context;        
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArticleController(Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _context.Articles.ToList();

            return View(values);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var allArticles = _context.Articles.ToList();

            var article = allArticles.FirstOrDefault(x => x.Id == id);

            if (article == null)
            {
                return NotFound(); // Belirtilen Id ile bir ekip üyesi bulunamadıysa hata döndürün.
            }

            return View(article);
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            // Logo (Açık Zemin) yüklemesi
            var CardImage = Request.Form.Files["CardImage"];
            if (CardImage != null && CardImage.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "CardImage");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + CardImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        CardImage.CopyTo(stream);
                    }
                    article.CardImage = "/UI/CardImage/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    // Hata yakalandığında hata mesajını görüntüle
                    Console.WriteLine(ex.Message);
                }
            }

            // Logo (Açık Zemin) yüklemesi
            var FullImage = Request.Form.Files["FullImage"];
            if (FullImage != null && FullImage.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "FullImage");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + FullImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                            FullImage.CopyTo(stream);
                    }
                    article.FullImage = "/UI/FullImage/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    // Hata yakalandığında hata mesajını görüntüle
                    Console.WriteLine(ex.Message);
                }
                
            }

            _context.Update(article);
            _context.SaveChanges();

            return View(article);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            // Logo (Açık Zemin) yüklemesi
            var CardImage = Request.Form.Files["CardImage"];
            if (CardImage != null && CardImage.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "Article");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + CardImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        CardImage.CopyTo(stream);
                    }
                    article.CardImage = "/UI/Article/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    // Hata yakalandığında hata mesajını görüntüle
                    Console.WriteLine(ex.Message);
                }              
            }

            var FullImage = Request.Form.Files["FullImage"];
            if (FullImage != null && FullImage.Length > 0)
            {
                // Dosyanın kaydedileceği dizini belirleyin (örnek olarak wwwroot/UI/Team)
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UI", "Article");

                // Dosya adını ve yolunu oluşturun
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + FullImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Logo (Açık Zemin) dosyasını kaydedin
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    FullImage.CopyTo(stream);
                }
                article.FullImage = "/UI/Article/" + uniqueFileName;
            }
           

            _context.Articles.Add(article);
            _context.SaveChanges();

            
            return RedirectToAction("Index", "Article", new { area = "Admin"});
        }
               
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // İlgili makaleyi veritabanından alın
            var article = _context.Articles.FirstOrDefault(x => x.Id == id);

            if (article == null)
            {
                return NotFound(); // Belirtilen Id ile bir makale bulunamadıysa hata döndürün.
            }

            // Makaleyi veritabanından kaldırın
            _context.Articles.Remove(article);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}


