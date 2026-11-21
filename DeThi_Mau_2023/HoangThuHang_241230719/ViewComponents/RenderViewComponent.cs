using Microsoft.AspNetCore.Mvc;
using HoangThuHang_241230719.Models;
namespace HoangThuHang_241230719.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;
        public RenderViewComponent(QlhangHoaContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiHangs = _context.LoaiHangs.ToList();
            return View("RenderHeader", loaiHangs);
        }
    }
}
