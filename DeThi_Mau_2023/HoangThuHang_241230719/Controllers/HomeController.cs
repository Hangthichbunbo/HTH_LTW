using HoangThuHang_241230719.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace HoangThuHang_241230719.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _context;
        public HomeController(QlhangHoaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listHangHoa = _context.HangHoas.Where(h => h.Gia >= 100).ToList();
            return View(listHangHoa);
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
        public IActionResult HangHoaByLoai(int maLoai)
        {
            var list = _context.HangHoas.Where(h => h.MaLoai == maLoai).ToList();
            return PartialView("_HangHoaPartial", list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, nameof(LoaiHang.MaLoai), nameof(LoaiHang.TenLoai));
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HangHoa hangHoa)
        {
            if(ModelState.IsValid)
            {
                _context.HangHoas.Add(hangHoa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, nameof(LoaiHang.MaLoai), nameof(LoaiHang.TenLoai), hangHoa.MaLoai);
            return View(hangHoa);
        }
    }
}
