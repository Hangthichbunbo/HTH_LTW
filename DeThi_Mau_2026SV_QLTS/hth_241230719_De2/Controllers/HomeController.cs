using hth_241230719_De1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace hth_241230719_De1.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext _context;
        public HomeController(QltaiSanContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TieuDe = "HOANG THU HANG";
            var dsTaiSan = _context.TaiSans.Include(t => t.MaLoaiNavigation).Where(t => t.NguyenGia != null && t.NguyenGia >= 20).ToList();

            return View(dsTaiSan);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult LocTheoLoai(int maloai)
        {
            if(maloai == 0)
            {
                ViewBag.TieuDe = "HOANG THU HANG";
                var dsTrangChu = _context.TaiSans.Include(t => t.MaLoaiNavigation).Where(t => t.NguyenGia != null && t.NguyenGia >= 20).ToList();
                return PartialView("_DanhSachTaiSanPartial", dsTrangChu);
            }
            var loai = _context.LoaiTaiSans.Find(maloai);
            ViewBag.TieuDe = loai?.TenLoai.ToUpper() ?? "DANH SACH TAI SAN";

            var dsTheoLoai = _context.TaiSans.Include(t => t.MaLoaiNavigation).Where(t => t.MaLoai == maloai).ToList();
            return PartialView("_DanhSachTaiSanPartial", dsTheoLoai);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taiSan = _context.TaiSans.Find(id);
            if (taiSan == null)
            {
                return NotFound();
            }
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai", taiSan.MaLoai);
            return View(taiSan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaiSan taiSan)
        {
            if (ModelState.IsValid)
            {
                _context.Update(taiSan);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai", taiSan.MaLoai);
            return View(taiSan);
        }
    }
}
