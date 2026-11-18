using Microsoft.EntityFrameworkCore;
using hoangthuhang_241230719.Models;
using Microsoft.AspNetCore.Mvc;
namespace hoangthuhang_241230719.ViewComponents
{
    public class TheLoaiMenuViewComponent : ViewComponent
    {
        private readonly QlnhaSachContext _context;
        public TheLoaiMenuViewComponent(QlnhaSachContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var dstheLoais = _context.TheLoais.ToList();
            return View(dstheLoais);
        }
    }
}
