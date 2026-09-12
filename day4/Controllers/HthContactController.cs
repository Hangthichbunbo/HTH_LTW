using Microsoft.AspNetCore.Mvc;

namespace day4.Controllers
{
    public class HthContactController : Controller
    {
        public IActionResult Index()
        {
            ViewData["hoten"] = "Hoàng Thu Hằng";
            ViewBag.age = "20";
            TempData["email"] = "hoanghang210926@gmail.com";
            return View();
        }
    }
}
