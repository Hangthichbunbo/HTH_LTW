using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hth_241230719_De1.Models;
namespace hth_241230719_De1.ViewComponents
{
    public class LoaiTaiSanMenuViewComponent : ViewComponent
    {
        private readonly QltaiSanContext _context;
        public LoaiTaiSanMenuViewComponent(QltaiSanContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dsLoai = await _context.LoaiTaiSans.ToListAsync();
            return View(dsLoai);
        }
    }
}
