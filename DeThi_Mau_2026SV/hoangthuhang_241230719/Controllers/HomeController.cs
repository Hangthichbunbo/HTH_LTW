using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hoangthuhang_241230719.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hoangthuhang_241230719.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext _context;
        public HomeController(QlnhaSachContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dsSach = _context.Saches.Include(s => s.MaTlNavigation).Where(s => s.Gia != null && s.Gia >= 100).ToList();
            return View(dsSach);
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

        public IActionResult GetSachByTheLoai(int maTl)
        {
            var dsSach = _context.Saches.Include(s => s.MaTlNavigation).Where(s => s.MaTl == maTl).ToList();
            return PartialView("_DanhSachSachPartial", dsSach);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Sach sach)
        {
            if(ModelState.IsValid)
            {
                _context.Saches.Add(sach);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl", sach.MaTl);
            return View(sach);
        }
    }
}
