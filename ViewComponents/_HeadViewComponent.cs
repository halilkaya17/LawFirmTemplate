using LawFirmTemplate.Data;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.ViewComponents
{
    public class _HeadViewComponent : ViewComponent
    {
        private readonly Context _context;

        public _HeadViewComponent(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.GeneralSettings.FirstOrDefault();

            return View(values);
        }
    }
}
