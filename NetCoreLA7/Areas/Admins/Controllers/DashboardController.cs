using Microsoft.AspNetCore.Mvc;

namespace NetCoreLA7.Areas.Admins.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Admins")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
