using Microsoft.AspNetCore.Mvc;

namespace HthLesson04Views.Controllers
{
    public class HthRazorCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
